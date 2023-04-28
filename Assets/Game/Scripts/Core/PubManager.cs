using System.Collections.Generic;
using System.Linq;
using PubSubPub.Messages;
using SuperMaxim.Messaging;
using UnityEngine;

namespace PubSubPub.Core
{
	public class PubManager : MonoBehaviour
	{
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
		private List<Customer> _customers;
		[SerializeField]
		[HideInInspector]
		private float _customerSpawnTimer;
		[SerializeField]
		[HideInInspector]
		private float _money;
		[SerializeField]
		[HideInInspector]
		private System.Random _random;

		private List<DrinkSettings> _drinkSettings;


		private void Awake()
		{
			_random = new System.Random();
			_drinkSettings = Resources.LoadAll<DrinkSettings>(_drinkSettingsFolderPath).ToList();
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
		}

		private void InstantiateCustomers()
		{
			_spawnRate -= _spawnRateDecreaseRate * Time.deltaTime;
			_customerSpawnTimer += Time.deltaTime;

			if(_customerSpawnTimer >= _spawnRate)
			{
				InstantiateCustomer();
				_customerSpawnTimer -= _spawnRate;
			}
		}

		private void InstantiateCustomer()
		{
			var customerGameObject = Instantiate(_customerPrefab);
			
			var customer = customerGameObject.GetComponent<Customer>();
			var money = _random.Next(_startingMoneyMin, _startingMoneyMax + 1);
			var drinkPreferenceWeights = GenerateDrinkPreferenceWeights();
			var drinkSpeed = (float)RandomHelpers.RandomRange(_random, _drinkRateMin, _drinkRateMax);
			var drunkenness = (float)_random.NextDouble() * _startingDrunkenessMax;
			customer.Initialize(money, drinkPreferenceWeights, drinkSpeed, drunkenness);

			_customers.Add(customer);

			Messenger.Default.Publish(new CustomerInstantiatedMessage(customer));
		}

		private Dictionary<DrinkSettings, float> GenerateDrinkPreferenceWeights()
		{
			var drinkPreferenceWeights = new Dictionary<DrinkSettings, float>();

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
			_customers.Remove(message.Customer);
			Messenger.Default.Publish(new CustomerRemovedMessage(message.Customer));
			Destroy(message.Customer.gameObject);
		}
	}
}
