using System;
using System.Collections.Generic;
using PubSubPub.Game.Core.Messages;
using SuperMaxim.Messaging;

namespace PubSubPub.Game.Core.Model
{
	public class CustomerFactory
	{
		private readonly ICustomerInstantiationSettings _customerInstantiationSettings;
		private readonly ICustomerSharedSettings _customerSharedSettings;
		private readonly List<IDrinkSettings> _drinkSettings;
		private readonly IMessenger _messenger;
		private readonly IRandom _random;
		private readonly ITime _time;


		public CustomerFactory(
				IMessenger messenger,
				IRandom random,
				ITime time,
				ICustomerInstantiationSettings customerInstantiationSettings,
				ICustomerSharedSettings customerSharedSettings,
				List<IDrinkSettings> drinkSettings)
		{
			if(messenger == null)
			{
				throw new ArgumentNullException(nameof(messenger));
			}

			if(random == null)
			{
				throw new ArgumentNullException(nameof(random));
			}

			if(time == null)
			{
				throw new ArgumentNullException(nameof(time));
			}

			if(customerInstantiationSettings == null)
			{
				throw new ArgumentNullException(nameof(customerInstantiationSettings));
			}

			if(customerSharedSettings == null)
			{
				throw new ArgumentNullException(nameof(customerSharedSettings));
			}

			if(drinkSettings == null || drinkSettings.Count == 0)
			{
				throw new ArgumentException($"{nameof(drinkSettings)} cannot be null or empty.");
			}

			if(customerInstantiationSettings.StartingMoneyMin < 0)
			{
				throw new ArgumentException($"{nameof(customerInstantiationSettings.StartingMoneyMin)} cannot "
						+ "be less than zero.");
			}

			if(customerInstantiationSettings.StartingMoneyMax < 0)
			{
				throw new ArgumentException($"{nameof(customerInstantiationSettings.StartingMoneyMax)} cannot "
						+ "be less than zero.");
			}

			if(customerInstantiationSettings.StartingMoneyMin
					> customerInstantiationSettings.StartingMoneyMax)
			{
				throw new ArgumentException($"{nameof(customerInstantiationSettings.StartingMoneyMin)} cannot "
						+ $"be greater than {nameof(customerInstantiationSettings.StartingMoneyMax)}.");
			}

			if(customerInstantiationSettings.StartingDrunkennessMax < 0f)
			{
				throw new ArgumentException($"{nameof(customerInstantiationSettings.StartingDrunkennessMax)} "
						+ "cannot be less than zero.");
			}

			if(customerInstantiationSettings.DrinkRateMin <= 0f)
			{
				throw new ArgumentException($"{nameof(customerInstantiationSettings.DrinkRateMin)} cannot be "
						+ "less than or equal to zero.");
			}

			if(customerInstantiationSettings.DrinkRateMax <= 0f)
			{
				throw new ArgumentException($"{nameof(customerInstantiationSettings.DrinkRateMax)} cannot be "
						+ "less than or equal to zero.");
			}

			if(customerInstantiationSettings.DrinkRateMin > customerInstantiationSettings.DrinkRateMax)
			{
				throw new ArgumentException($"{nameof(customerInstantiationSettings.DrinkRateMin)} cannot be "
						+ $"greater than {nameof(customerInstantiationSettings.DrinkRateMax)}.");
			}

			_customerInstantiationSettings = customerInstantiationSettings;
			_customerSharedSettings = customerSharedSettings;
			_drinkSettings = drinkSettings;
			_messenger = messenger;
			_random = random;
			_time = time;

			_messenger.Subscribe<CustomerInstantiateRequestedMessage>(OnCustomerInstantiateRequestedMessage);
		}


		private void OnCustomerInstantiateRequestedMessage(CustomerInstantiateRequestedMessage message)
		{
			var money = _random.Next(_customerInstantiationSettings.StartingMoneyMin,
					_customerInstantiationSettings.StartingMoneyMax + 1);
			var drinkPreferenceWeights = GenerateDrinkPreferenceWeights();
			var drinkRate = (float)RandomHelpers.RandomRange(_random, _customerInstantiationSettings.DrinkRateMin,
					_customerInstantiationSettings.DrinkRateMax);
			var drunkenness = (float)_random.NextDouble() * _customerInstantiationSettings.StartingDrunkennessMax;
			var customer = new Customer(_messenger, _time, _random, _customerSharedSettings, money,
					drinkPreferenceWeights, drinkRate, drunkenness);

			_messenger.Publish(new CustomerInstantiatedMessage(customer));
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
	}
}
