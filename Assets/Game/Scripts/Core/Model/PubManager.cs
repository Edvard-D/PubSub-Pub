using System.Collections.Generic;
using System.Linq;
using PubSubPub.Game.Core.Messages;
using SuperMaxim.Messaging;
using UnityEngine;

namespace PubSubPub.Game.Core.Model
{
	public class PubManager : MonoBehaviour
	{
		[SerializeField]
		private CustomerSharedSettings _customerSharedSettings;
		[SerializeField]
		private string _drinkSettingsFolderPath;
		[SerializeField]
		private GameObject _customerPrefab;
		[SerializeField]
		private float _spawnRate;
		[SerializeField]
		private float _spawnRateDecreaseRate;
		[SerializeField]
		private int _startingMoneyMin;
		[SerializeField]
		private int _startingMoneyMax;
		[SerializeField]
		private float _startingDrunkenessMax;
		[SerializeField]
		private float _drinkRateMin;
		[SerializeField]
		private float _drinkRateMax;

		[SerializeField]
		[HideInInspector]
		private Dictionary<Customer, GameObject> _customers;
		[SerializeField]
		[HideInInspector]
		private float _customerSpawnTimer;
		[SerializeField]
		[HideInInspector]
		private float _money;
		[SerializeField]
		[HideInInspector]
		private IRandom _random;

		private List<DrinkSettings> _drinkSettings;
		private ITime _time;


		private void Awake()
		{
			_random = new Model.Random();
			_drinkSettings = Resources.LoadAll<DrinkSettings>(_drinkSettingsFolderPath).ToList();
			_time = new TimeWrapper();
		}
		
		private void OnEnable()
		{
			Messenger.Default.Subscribe<CustomerDrinkSoldMessage>(OnCustomerDrinkSoldMessage);
			Messenger.Default.Subscribe<CustomerRemovalInitiatedMessage>(OnCustomerRemovalInitiatedMessage);
		}

		private void OnDisable()
		{
			Messenger.Default.Unsubscribe<CustomerDrinkSoldMessage>(OnCustomerDrinkSoldMessage);
			Messenger.Default.Unsubscribe<CustomerRemovalInitiatedMessage>(OnCustomerRemovalInitiatedMessage);
		}

		private void Update()
		{
			InstantiateCustomers();
			UpdateCustomers();
		}

		private void InstantiateCustomers()
		{
			_spawnRate -= _spawnRateDecreaseRate * _time.DeltaTime;
			_customerSpawnTimer += _time.DeltaTime;

			if(_customerSpawnTimer >= _spawnRate)
			{
				InstantiateCustomer();
				_customerSpawnTimer -= _spawnRate;
			}
		}

		private void UpdateCustomers()
		{
			foreach(var customer in _customers.Keys)
			{
				customer.Update();
			}
		}

		private void InstantiateCustomer()
		{
			var customerGameObject = Instantiate(_customerPrefab);
			var money = _random.Next(_startingMoneyMin, _startingMoneyMax + 1);
			var drinkPreferenceWeights = GenerateDrinkPreferenceWeights();
			var drinkSpeed = (float)RandomHelpers.RandomRange(_random, _drinkRateMin, _drinkRateMax);
			var drunkenness = (float)_random.NextDouble() * _startingDrunkenessMax;
			var customer = new Customer(_random, _customerSharedSettings, money,
					drinkPreferenceWeights, drinkSpeed, drunkenness);
			customer.Initialize(Messenger.Default, _time);
			_customers.Add(customer, gameObject);

			Messenger.Default.Publish(new CustomerInstantiatedMessage(customer));
		}

		private Dictionary<IDrinkSettings, float> GenerateDrinkPreferenceWeights()
		{
			var drinkPreferenceWeights = new Dictionary<IDrinkSettings, float>();

			foreach(var drinkSettings in _drinkSettings)
			{
				drinkPreferenceWeights.Add(drinkSettings, (float)_random.NextDouble());
			}

			return drinkPreferenceWeights;
		}

		private void OnCustomerDrinkSoldMessage(CustomerDrinkSoldMessage message)
		{
			_money += message.Drink.Settings.Price;
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
