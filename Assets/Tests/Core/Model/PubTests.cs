using System;
using System.Collections.Generic;
using NUnit.Framework;
using PubSubPub.Game.Core.Messages;
using PubSubPub.Game.Core.Model;
using PubSubPub.Tests.Stubs;
using PubSubPub.Tests.Stubs.Core.Model;
using PubSubPub.Tests.Stubs.Messages;

namespace PubSubPub.Tests.Core.Model
{
	public class PubTests
	{
		[Test]
		public void Constructor_ThrowsArgumentNullException_WhenMessengerIsNull()
		{
			var time = new TimeStub();
			var pubSettings = new PubSettingsStub
			{
				CustomerStartingDelayBetweenSpawns = 1f,
				CustomerMinDelayBetweenSpawns = 1f,
				CustomerDelayBetweenSpawnsDecreaseRate = 1f
			};

			Assert.Throws<ArgumentNullException>(() => new Pub(null, time, pubSettings));
		}

		[Test]
		public void Constructor_ThrowsArgumentNullException_WhenTimeIsNull()
		{
			var messenger = new MessengerStub();
			var pubSettings = new PubSettingsStub
			{
				CustomerStartingDelayBetweenSpawns = 1f,
				CustomerMinDelayBetweenSpawns = 1f,
				CustomerDelayBetweenSpawnsDecreaseRate = 1f
			};

			Assert.Throws<ArgumentNullException>(() => new Pub(messenger, null, pubSettings));
		}

		[Test]
		public void Constructor_ThrowsArgumentNullException_WhenPubSettingsIsNull()
		{
			var messenger = new MessengerStub();
			var time = new TimeStub();

			Assert.Throws<ArgumentNullException>(() => new Pub(messenger, time, null));
		}

		[Test]
		public void Constructor_ThrowsArgumentException_WhenCustomerStartingDelayBetweenSpawnsIsZero()
		{
			var messenger = new MessengerStub();
			var time = new TimeStub();
			var pubSettings = new PubSettingsStub
			{
				CustomerMinDelayBetweenSpawns = 1f,
				CustomerStartingDelayBetweenSpawns = 0f
			};

			Assert.Throws<ArgumentException>(() => new Pub(messenger, time, pubSettings));
		}

		[Test]
		public void Constructor_ThrowsArgumentException_WhenCustomerStartingDelayBetweenSpawnsIsLessThanZero()
		{
			var messenger = new MessengerStub();
			var time = new TimeStub();
			var pubSettings = new PubSettingsStub
			{
				CustomerMinDelayBetweenSpawns = 1f,
				CustomerStartingDelayBetweenSpawns = -1f
			};

			Assert.Throws<ArgumentException>(() => new Pub(messenger, time, pubSettings));
		}

		[Test]
		public void Constructor_DoesNotThrowArgumentException_WhenCustomerStartingDelayBetweenSpawnsIsGreaterThanZero()
		{
			var messenger = new MessengerStub();
			var time = new TimeStub();
			var pubSettings = new PubSettingsStub
			{
				CustomerStartingDelayBetweenSpawns = 1f,
				CustomerMinDelayBetweenSpawns = 1f,
				CustomerDelayBetweenSpawnsDecreaseRate = 1f
			};

			Assert.DoesNotThrow(() => new Pub(messenger, time, pubSettings));
		}

		[Test]
		public void Constructor_ThrowsArgumentException_WhenCustomerMinDelayBetweenSpawnsIsZero()
		{
			var messenger = new MessengerStub();
			var time = new TimeStub();
			var pubSettings = new PubSettingsStub
			{
				CustomerStartingDelayBetweenSpawns = 1f,
				CustomerMinDelayBetweenSpawns = 0f,
				CustomerDelayBetweenSpawnsDecreaseRate = 1f
			};

			Assert.Throws<ArgumentException>(() => new Pub(messenger, time, pubSettings));
		}

		[Test]
		public void Constructor_ThrowsArgumentException_WhenCustomerMinDelayBetweenSpawnsIsBelowZero()
		{
			var messenger = new MessengerStub();
			var time = new TimeStub();
			var pubSettings = new PubSettingsStub
			{
				CustomerStartingDelayBetweenSpawns = 1f,
				CustomerMinDelayBetweenSpawns = -1f,
				CustomerDelayBetweenSpawnsDecreaseRate = 1f
			};

			Assert.Throws<ArgumentException>(() => new Pub(messenger, time, pubSettings));
		}

		[Test]
		public void Constructor_ThrowsArgumentException_WhenCustomerMinDelayBetweenSpawnsIsGreaterThanCustomerStartingDelayBetweenSpawns()
		{
			var customerStartingDelayBetweenSpawns = 1f;
			var customerMinDelayBetweenSpawns = customerStartingDelayBetweenSpawns + 1f;
			var messenger = new MessengerStub();
			var time = new TimeStub();
			var pubSettings = new PubSettingsStub
			{
				CustomerStartingDelayBetweenSpawns = customerStartingDelayBetweenSpawns,
				CustomerMinDelayBetweenSpawns = customerMinDelayBetweenSpawns,
				CustomerDelayBetweenSpawnsDecreaseRate = 1f
			};

			Assert.Throws<ArgumentException>(() => new Pub(messenger, time, pubSettings));
		}

		[Test]
		public void Constructor_ThrowsArgumentException_WhenCustomerDelayBetweenSpawnsDecreaseRateIsZero()
		{
			var messenger = new MessengerStub();
			var time = new TimeStub();
			var pubSettings = new PubSettingsStub
			{
				CustomerStartingDelayBetweenSpawns = 1f,
				CustomerMinDelayBetweenSpawns = 1f,
				CustomerDelayBetweenSpawnsDecreaseRate = 0f
			};

			Assert.Throws<ArgumentException>(() => new Pub(messenger, time, pubSettings));
		}

		[Test]
		public void Constructor_ThrowsArgumentException_WhenCustomerDelayBetweenSpawnsDecreaseRateIsLessThanZero()
		{
			var messenger = new MessengerStub();
			var time = new TimeStub();
			var pubSettings = new PubSettingsStub
			{
				CustomerStartingDelayBetweenSpawns = 1f,
				CustomerMinDelayBetweenSpawns = 1f,
				CustomerDelayBetweenSpawnsDecreaseRate = -1f
			};

			Assert.Throws<ArgumentException>(() => new Pub(messenger, time, pubSettings));
		}

		[Test]
		public void Constructor_DoesNotThrowArgumentException_WhenCustomerDelayBetweenSpawnsDecreaseRateIsGreaterThanZero()
		{
			var messenger = new MessengerStub();
			var time = new TimeStub();
			var pubSettings = new PubSettingsStub
			{
				CustomerStartingDelayBetweenSpawns = 1f,
				CustomerMinDelayBetweenSpawns = 1f,
				CustomerDelayBetweenSpawnsDecreaseRate = 1f
			};

			Assert.DoesNotThrow(() => new Pub(messenger, time, pubSettings));
		}

		[Test]
		public void Update_PublishesCustomerInstantiateRequestedMessage_WhenNoCustomerHasBeenInstantiatedYet()
		{
			var messenger = new MessengerStub();
			var time = new TimeStub();
			var pubSettings = new PubSettingsStub
			{
				CustomerStartingDelayBetweenSpawns = 1f,
				CustomerMinDelayBetweenSpawns = 1f,
				CustomerDelayBetweenSpawnsDecreaseRate = 1f
			};
			var pub = new Pub(messenger, time, pubSettings);
			var customerInstantiateRequestedMessageSubscriber =
					new CustomerInstantiateRequestedMessageSubscriberStub(messenger);

			pub.Update();

			Assert.IsNotNull(customerInstantiateRequestedMessageSubscriber.Message);
		}

		[Test]
		public void Update_DoesNotPublishCustomerInstantiateRequestedMessage_WhenCustomerWasInstantiatedLessThanCustomerStartingDelayBetweenSpawnsAgo()
		{
			var messenger = new MessengerStub();
			var time = new TimeStub();
			var pubSettings = new PubSettingsStub
			{
				CustomerStartingDelayBetweenSpawns = 2f,
				CustomerMinDelayBetweenSpawns = 1f,
				CustomerDelayBetweenSpawnsDecreaseRate = 1f
			};
			var pub = new Pub(messenger, time, pubSettings);
			var customerInstantiateRequestedMessageSubscriber =
					new CustomerInstantiateRequestedMessageSubscriberStub(messenger);

			pub.Update();
			customerInstantiateRequestedMessageSubscriber.Message = null;
			pub.Update();

			Assert.IsNull(customerInstantiateRequestedMessageSubscriber.Message);
		}

		[Test]
		public void Update_PublishesCustomerInstantiateRequestedMessage_WhenCustomerWasInstantiatedLongerThanCustomerStartingDelayBetweenSpawnsAgo()
		{
			var customerStartingDelayBetweenSpawns = 1f;
			var messenger = new MessengerStub();
			var time = new TimeStub();
			var pubSettings = new PubSettingsStub
			{
				CustomerStartingDelayBetweenSpawns = customerStartingDelayBetweenSpawns,
				CustomerMinDelayBetweenSpawns = 1f,
				CustomerDelayBetweenSpawnsDecreaseRate = 1f
			};
			var pub = new Pub(messenger, time, pubSettings);
			var customerInstantiateRequestedMessageSubscriber =
					new CustomerInstantiateRequestedMessageSubscriberStub(messenger);

			pub.Update();
			customerInstantiateRequestedMessageSubscriber.Message = null;
			time.DeltaTime = customerStartingDelayBetweenSpawns;
			pub.Update();

			Assert.IsNotNull(customerInstantiateRequestedMessageSubscriber.Message);
		}

		[Test]
		public void Update_PublishesCustomerInstantiateRequestedMessage_WhenDoubleTheLengthOfCustomerStartingDelayBetweenSpawnsAgoHasPassedAfterFirstSpawnAndBeforeSecondSpawn()
		{
			var customerStartingDelayBetweenSpawns = 1f;
			var messenger = new MessengerStub();
			var time = new TimeStub();
			var pubSettings = new PubSettingsStub
			{
				CustomerStartingDelayBetweenSpawns = customerStartingDelayBetweenSpawns,
				CustomerMinDelayBetweenSpawns = 1f,
				CustomerDelayBetweenSpawnsDecreaseRate = 1f
			};
			var pub = new Pub(messenger, time, pubSettings);
			var customerInstantiateRequestedMessageSubscriber =
					new CustomerInstantiateRequestedMessageSubscriberStub(messenger);

			pub.Update();
			time.DeltaTime = customerStartingDelayBetweenSpawns * 2f;
			pub.Update();
			time.DeltaTime = 0.01f;
			customerInstantiateRequestedMessageSubscriber.Message = null;
			pub.Update();

			Assert.IsNotNull(customerInstantiateRequestedMessageSubscriber.Message);
		}

		[Test]
		public void Update_PublishesCustomerInstantiateRequestedMessage_WhenCustomerWasInstantiatedLessThanCustomerDelayBetweenSpawnsDecreaseRateAgoAndCustomerMinDelayBetweenSpawnsIsLessThanDeltaTime()
		{
			var customerDelayBetweenSpawnsDecreaseRate = 1f;
			var deltaTime = customerDelayBetweenSpawnsDecreaseRate - 0.01f;
			var messenger = new MessengerStub();
			var time = new TimeStub();
			var pubSettings = new PubSettingsStub
			{
				CustomerStartingDelayBetweenSpawns = 1f,
				CustomerMinDelayBetweenSpawns = deltaTime - 0.01f,
				CustomerDelayBetweenSpawnsDecreaseRate = customerDelayBetweenSpawnsDecreaseRate
			};
			var pub = new Pub(messenger, time, pubSettings);
			var customerInstantiateRequestedMessageSubscriber =
					new CustomerInstantiateRequestedMessageSubscriberStub(messenger);

			pub.Update();
			customerInstantiateRequestedMessageSubscriber.Message = null;
			time.DeltaTime = deltaTime;
			pub.Update();

			Assert.IsNotNull(customerInstantiateRequestedMessageSubscriber.Message);
		}

		[Test]
		public void Update_DoesNotPublishCustomerInstantiateRequestedMessage_WhenCustomerMinDelayBetweenSpawnsIsOneAndCustomerDelayBetweenSpawnsDecreaseRateIsOneAndDeltaTimeBetweenSpawnsIsLessThanOne()
		{
			var customerMinDelayBetweenSpawns = 1f;
			var customerDelayBetweenSpawnsDecreaseRate = 1f;
			var messenger = new MessengerStub();
			var time = new TimeStub();
			var pubSettings = new PubSettingsStub
			{
				CustomerStartingDelayBetweenSpawns = 1f,
				CustomerMinDelayBetweenSpawns = customerMinDelayBetweenSpawns,
				CustomerDelayBetweenSpawnsDecreaseRate = customerDelayBetweenSpawnsDecreaseRate
			};
			var pub = new Pub(messenger, time, pubSettings);
			var customerInstantiateRequestedMessageSubscriber =
					new CustomerInstantiateRequestedMessageSubscriberStub(messenger);

			pub.Update();
			customerInstantiateRequestedMessageSubscriber.Message = null;
			time.DeltaTime = customerMinDelayBetweenSpawns - 0.1f;
			pub.Update();

			Assert.IsNull(customerInstantiateRequestedMessageSubscriber.Message);
		}

		[Test]
		public void MoneyIncreases_WhenCustomerDrinkSoldMessageIsPublished()
		{
			var drinkPrice = 1;
			var messenger = new MessengerStub();
			var random = new RandomStub();
			var time = new TimeStub();
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
			var pubSettings = new PubSettingsStub()
			{
				CustomerStartingDelayBetweenSpawns = 1f,
				CustomerMinDelayBetweenSpawns = 1f,
				CustomerDelayBetweenSpawnsDecreaseRate = 1f
			};
			var drink1Settings = new DrinkSettingsStub("drink1", drinkPrice, 1f);
			var drinkPreferenceWeights = new Dictionary<IDrinkSettings, float>()
			{
				{ drink1Settings, 1f }
			};
			var pub = new Pub(messenger, time, pubSettings);
			var customer = new Customer(messenger, time, random, customerSharedSettings, 0, drinkPreferenceWeights,
					1f, 0f);
			var drink = new Drink(drink1Settings);

			messenger.Publish(new CustomerDrinkSoldMessage(customer, drink));

			Assert.AreEqual(drinkPrice, pub.Money);
		}
	}
}
