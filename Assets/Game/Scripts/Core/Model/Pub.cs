using System;
using System.Collections.Generic;
using PubSubPub.Game.Core.Messages;
using SuperMaxim.Messaging;
using UnityEngine;

namespace PubSubPub.Game.Core.Model
{
	[Serializable]
	public class Pub
	{
		[SerializeField]
		[HideInInspector]
		private int _money;
		[SerializeField]
		[HideInInspector]
		private float _spawnRate;
		[SerializeField]
		[HideInInspector]
		private float _timeSinceLastSpawn;

		private readonly IMessenger _messenger;
		private readonly IPubSettings _pubSettings;
		private readonly ITime _time;


		public Pub(
				IMessenger messenger,
				ITime time,
				IPubSettings pubSettings)
		{
			if(messenger == null)
			{
				throw new ArgumentNullException(nameof(messenger));
			}

			if(time == null)
			{
				throw new ArgumentNullException(nameof(time));
			}

			if(pubSettings == null)
			{
				throw new ArgumentNullException(nameof(pubSettings));
			}

			if(pubSettings.CustomerStartingDelayBetweenSpawns <= 0f)
			{
				throw new ArgumentException($"{nameof(pubSettings.CustomerStartingDelayBetweenSpawns)} cannot be less "
						+ "than or equal to zero.");
			}

			if(pubSettings.CustomerMinDelayBetweenSpawns <= 0f)
			{
				throw new ArgumentException($"{nameof(pubSettings.CustomerMinDelayBetweenSpawns)} cannot be less than "
						+ "or equal to zero.");
			}

			if(pubSettings.CustomerMinDelayBetweenSpawns > pubSettings.CustomerStartingDelayBetweenSpawns)
			{
				throw new ArgumentException($"{nameof(pubSettings.CustomerMinDelayBetweenSpawns)} cannot be greater "
						+ $"than {nameof(pubSettings.CustomerStartingDelayBetweenSpawns)}.");
			}

			if(pubSettings.CustomerDelayBetweenSpawnsDecreaseRate <= 0f)
			{
				throw new ArgumentException($"{nameof(pubSettings.CustomerDelayBetweenSpawnsDecreaseRate)} cannot be "
						+ "less than or equal to zero.");
			}

			_messenger = messenger;
			_pubSettings = pubSettings;
			_spawnRate = _pubSettings.CustomerStartingDelayBetweenSpawns;
			_time = time;
			_timeSinceLastSpawn = _pubSettings.CustomerStartingDelayBetweenSpawns;

			_messenger.Subscribe<CustomerDrinkSoldMessage>(OnCustomerDrinkSoldMessage);
		}


		public int Money { get { return _money; } }


		public void Update()
		{
			TryInstantiateCustomers();
		}

		public void Destory()
		{
			_messenger.Unsubscribe<CustomerDrinkSoldMessage>(OnCustomerDrinkSoldMessage);
		}

		private void TryInstantiateCustomers()
		{
			_timeSinceLastSpawn += _time.DeltaTime;

			if(_timeSinceLastSpawn < _spawnRate)
			{
				return;
			}

			_messenger.Publish(new CustomerInstantiateRequestedMessage(0, new Dictionary<IDrinkSettings, float>(), 0f,
					0f));
			_timeSinceLastSpawn -= _spawnRate;
			_spawnRate -= _pubSettings.CustomerDelayBetweenSpawnsDecreaseRate;
			_spawnRate = Mathf.Max(_spawnRate, _pubSettings.CustomerMinDelayBetweenSpawns);
		}

		private void OnCustomerDrinkSoldMessage(CustomerDrinkSoldMessage message)
		{
			_money += message.Drink.Settings.Price;
		}
	}
}
