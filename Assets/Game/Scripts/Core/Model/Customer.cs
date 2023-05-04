using System;
using System.Collections.Generic;
using System.Linq;
using PubSubPub.Game.Core.Messages;
using SuperMaxim.Messaging;
using UnityEngine;

namespace PubSubPub.Game.Core.Model
{
	[Serializable]
	public class Customer
	{
		[SerializeField]
		[HideInInspector]
		private ICustomerSharedSettings _customerSharedSettings;
		[SerializeField]
		[HideInInspector]
		private Drink _drink;
		[SerializeField]
		[HideInInspector]
		private Dictionary<IDrinkSettings, float> _drinkPreferenceWeights;
		[SerializeField]
		[HideInInspector]
		private float _drinkRate;
		[SerializeField]
		[HideInInspector]
		private float _drunkenness;
		[SerializeField]
		[HideInInspector]
		private GameObject _gameObject;
		[SerializeField]
		[HideInInspector]
		private float _lastDrinkFinishedTime = 0f;
		[SerializeField]
		[HideInInspector]
		private int _money;
		[SerializeField]
		[HideInInspector]
		private IRandom _random;
		[SerializeField]
		[HideInInspector]
		private bool _wasCustomerReadyForNewDrinkMessageSent = false;

		private IMessenger _messenger;
		private ITime _time;


		public Customer(
				GameObject gameObject,
				IRandom random,
				ICustomerSharedSettings customerSharedSettings,
				int money,
				Dictionary<IDrinkSettings, float> drinkPreferenceWeights,
				float drinkRate,
				float drunkenness)
		{
			if(drinkRate <= 0f)
			{
				throw new ArgumentException($"{nameof(drinkRate)} must be greater than 0.");
			}

			if(drunkenness < 0f)
			{
				throw new ArgumentException($"{nameof(drunkenness)} must be greater than or equal to 0.");
			}

			if(money < 0)
			{
				throw new ArgumentException($"{nameof(money)} must be greater than or equal to 0.");
			}

			if(customerSharedSettings.DrunkennessIncreaseMultiplier <= 0f)
			{
				throw new ArgumentException(nameof(customerSharedSettings.DrunkennessIncreaseMultiplier)
						+ " must be greater than 0.");
			}

			if(customerSharedSettings.DrunkennessPassedOutThreshold <= 0f
				|| customerSharedSettings.DrunkennessPassedOutThreshold > 1f)
			{
				throw new ArgumentException(nameof(customerSharedSettings.DrunkennessPassedOutThreshold)
						+ " must be greater than 0 and less than or equal to 1.");
			}

			if(customerSharedSettings.DelayBetweenDrinks <= 0f)
			{
				throw new ArgumentException(nameof(customerSharedSettings.DelayBetweenDrinks)
						+ " must be greater than 0.");
			}

			_customerSharedSettings = customerSharedSettings;
			_drinkPreferenceWeights = drinkPreferenceWeights;
			_drinkRate = drinkRate;
			_drunkenness = drunkenness;
			_gameObject = gameObject;
			_money = money;
			_random = random;

			_messenger.Subscribe<CustomerDrinkSaleInitiatedMessage>(ChangeDrink,
					(CustomerDrinkSaleInitiatedMessage message) => message.Customer == this);
			_messenger.Subscribe<DrinkFillAmountChangedMessage>(OnDrinkFillAmountChangedMessage,
					(DrinkFillAmountChangedMessage message) => message.Drink == _drink);
		}


		private float Drunkenness
		{
			get { return _drunkenness; }
			set
			{
				if(_drunkenness == value)
				{
					return;
				}

				var previousDrunkenness = _drunkenness;
				_drunkenness = value;
				
				if(IsPassedOut == true)
				{
					return;
				}

				_messenger.Publish(new CustomerPassedOutMessage(this));
			}
		}
		public GameObject GameObject { get { return _gameObject; } }
		public bool IsPassedOut { get { return _drunkenness >= _customerSharedSettings.DrunkennessPassedOutThreshold; } }


		public void Initialize(
				IMessenger messenger,
				ITime time)
		{
			_messenger = messenger;
			_time = time;
		}

		public void Update()
		{
			TryDrinkDrink();
			TryRequestNewDrink();
		}

		public void Destroy()
		{
			_messenger.Unsubscribe<CustomerDrinkSaleInitiatedMessage>(ChangeDrink);
			_messenger.Unsubscribe<DrinkFillAmountChangedMessage>(OnDrinkFillAmountChangedMessage);
		}

		private void TryDrinkDrink()
		{
			if(_drink == null)
			{
				return;
			}

			var amountToDrink = _drinkRate * _time.DeltaTime;
			amountToDrink = Mathf.Clamp01(Mathf.Min(amountToDrink, _drink.FillAmount));
			_drink.DrinkDrink(amountToDrink);
			Drunkenness += amountToDrink * _drink.Settings.AlcoholPercent
					* _customerSharedSettings.DrunkennessIncreaseMultiplier;
		}

		private void TryRequestNewDrink()
		{
			if(_drink != null
				|| IsPassedOut == true
				|| _lastDrinkFinishedTime + _customerSharedSettings.DelayBetweenDrinks > _time.Time
				|| _wasCustomerReadyForNewDrinkMessageSent == true)
			{
				return;
			}
			
			_messenger.Publish(new CustomerNewDrinkRequestedMessage(this, SelectRandomDrink()));
			_wasCustomerReadyForNewDrinkMessageSent = true;
		}

		private IDrinkSettings SelectRandomDrink()
		{
			var totalWeight = _drinkPreferenceWeights.Sum(kvp => kvp.Value);

			var randomWeight = RandomHelpers.RandomRange(_random, 0f, totalWeight);
			foreach(var drinkPreferenceWeight in _drinkPreferenceWeights)
			{
				randomWeight -= drinkPreferenceWeight.Value;
				if(randomWeight > 0f)
				{
					continue;
				}

				return drinkPreferenceWeight.Key;
			}

			throw new System.InvalidOperationException("Could not select a random drink.");
		}

		private void OnDrinkFillAmountChangedMessage(DrinkFillAmountChangedMessage message)
		{
			if(_drink.FillAmount > 0f)
			{
				return;
			}

			_drink = null;
			_lastDrinkFinishedTime = _time.Time;
			_wasCustomerReadyForNewDrinkMessageSent = false;
		}

		private void ChangeDrink(CustomerDrinkSaleInitiatedMessage message)
		{
			if(_drink != null || _money < message.DrinkSettings.Price)
			{
				return;
			}

			_drink = new Drink(message.DrinkSettings);
			_drink.Initialize(_messenger);
			_money -= message.DrinkSettings.Price;
			_messenger.Publish(new CustomerDrinkSoldMessage(this, _drink));
		}
	}
}
