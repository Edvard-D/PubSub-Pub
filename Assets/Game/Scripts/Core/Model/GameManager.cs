using System.Collections.Generic;
using System.Linq;
using PubSubPub.Game.Core.Messages;
using SuperMaxim.Messaging;
using UnityEngine;

namespace PubSubPub.Game.Core.Model
{
	public class GameManager : MonoBehaviour
	{
		[SerializeField]
		private PubSettings _pubSettings;
		[SerializeField]
		private CustomerInstantiationSettings _customerInstantiationSettings;
		[SerializeField]
		private CustomerSharedSettings _customerSharedSettings;
		[SerializeField]
		private string _drinkSettingsFolderPath;
		[SerializeField]
		private GameObject _customerPrefab;

		[SerializeField]
		[HideInInspector]
		private Dictionary<Customer, GameObject> _customers;
		[SerializeField]
		[HideInInspector]
		private Pub _pub;
		[SerializeField]
		[HideInInspector]
		private IRandom _random;

		private CustomerFactory _customerFactory;
		private List<IDrinkSettings> _drinkSettings;
		private ITime _time;


		private void Awake()
		{
			_drinkSettings = Resources.LoadAll<DrinkSettings>(_drinkSettingsFolderPath)
					.Cast<IDrinkSettings>()
					.ToList();
			_random = new Model.Random();
			_time = new TimeWrapper();

			_customerFactory = new CustomerFactory(Messenger.Default, _random, _time, _customerInstantiationSettings,
					_customerSharedSettings, _drinkSettings);
			_pub = new Pub(Messenger.Default, _time, _pubSettings);
		}
		
		private void OnEnable()
		{
			Messenger.Default.Subscribe<CustomerInstantiatedMessage>(OnCustomerInstantiatedMessage);
			Messenger.Default.Subscribe<CustomerRemovalInitiatedMessage>(OnCustomerRemovalInitiatedMessage);
		}

		private void OnDisable()
		{
			Messenger.Default.Unsubscribe<CustomerInstantiatedMessage>(OnCustomerInstantiatedMessage);
			Messenger.Default.Unsubscribe<CustomerRemovalInitiatedMessage>(OnCustomerRemovalInitiatedMessage);
		}

		private void Update()
		{
			_pub.Update();
			UpdateCustomers();
		}

		private void UpdateCustomers()
		{
			foreach(var customer in _customers.Keys)
			{
				customer.Update();
			}
		}

		private void OnCustomerInstantiatedMessage(CustomerInstantiatedMessage message)
		{
			var customerGameObject = Instantiate(_customerPrefab);
			_customers.Add(message.Customer, gameObject);
		}

		private void OnCustomerRemovalInitiatedMessage(CustomerRemovalInitiatedMessage message)
		{
			Messenger.Default.Publish(new CustomerRemovedMessage(message.Customer));
			message.Customer.Destroy();
			Destroy(_customers[message.Customer]);
			_customers.Remove(message.Customer);
		}
	}
}
