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
		private ICustomerSharedSettings _customerSettings;
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
		private System.Random _random;
		[SerializeField]
		[HideInInspector]
		private bool _wasCustomerReadyForNewDrinkMessageSent = false;


		public Customer(
				GameObject gameObject,
				ICustomerSharedSettings customerSettings,
				int money,
				Dictionary<IDrinkSettings, float> drinkPreferenceWeights,
				float drinkRate,
				float drunkenness)
		{
			_customerSettings = customerSettings;
			_drinkPreferenceWeights = drinkPreferenceWeights;
			_drinkRate = drinkRate;
			_drunkenness = drunkenness;
			_gameObject = gameObject;
			_money = money;
			_random = new System.Random();

			Messenger.Default.Subscribe<CustomerDrinkSaleInitiatedMessage>(ChangeDrink,
					(CustomerDrinkSaleInitiatedMessage message) => message.Customer == this);
			Messenger.Default.Subscribe<DrinkFillAmountChangedMessage>(OnDrinkFillAmountChangedMessage,
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

				Messenger.Default.Publish(new CustomerPassedOutMessage(this));
			}
		}
		public GameObject GameObject { get { return _gameObject; } }
		public bool IsPassedOut { get { return _drunkenness >= _customerSettings.DrunkennessPassedOutThreshold; } }


		public void Update()
		{
			TryDrinkDrink();
			TryRequestNewDrink();
		}

		public void Destroy()
		{
			Messenger.Default.Unsubscribe<CustomerDrinkSaleInitiatedMessage>(ChangeDrink);
			Messenger.Default.Unsubscribe<DrinkFillAmountChangedMessage>(OnDrinkFillAmountChangedMessage);
		}

		private void TryDrinkDrink()
		{
			if(_drink == null)
			{
				return;
			}

			var amountToDrink = _drinkRate * Time.deltaTime;
			amountToDrink = Mathf.Clamp01(Mathf.Min(amountToDrink, _drink.FillAmount));
			_drink.DrinkDrink(amountToDrink);
			Drunkenness += amountToDrink * _drink.Settings.AlcoholPercent
					* _customerSettings.DrunkennessIncreaseMultiplier;
		}

		private void TryRequestNewDrink()
		{
			if(IsPassedOut == true
				|| _lastDrinkFinishedTime + _customerSettings.DelayBetweenDrinks > Time.time
				|| _wasCustomerReadyForNewDrinkMessageSent == true)
			{
				return;
			}
			
			Messenger.Default.Publish(new CustomerNewDrinkRequestedMessage(this, SelectRandomDrink()));
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
			_lastDrinkFinishedTime = Time.time;
			_wasCustomerReadyForNewDrinkMessageSent = false;
		}

		private void ChangeDrink(CustomerDrinkSaleInitiatedMessage message)
		{
			if(_drink != null || _money < message.DrinkSettings.Price)
			{
				return;
			}

			_drink = new Drink(message.DrinkSettings);
			_money -= message.DrinkSettings.Price;
			Messenger.Default.Publish(new CustomerDrinkSoldMessage(this, _drink));
		}
	}
}
