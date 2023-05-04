using System;
using System.Collections.Generic;
using NUnit.Framework;
using PubSubPub.Game.Core.Messages;
using PubSubPub.Game.Core.Model;
using PubSubPub.Tests.Stubs;
using SuperMaxim.Messaging;

namespace PubSubPub.Tests.Core.Model
{
    public class CustomerTests
    {
		[Test]
		public void Constructor_ThrowsArgumentNullException_WhenRandomIsNull()
		{
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
			var drinkPreferenceWeights = new Dictionary<IDrinkSettings, float>();

			Assert.Throws<ArgumentNullException>(() => new Customer(null, null, customerSharedSettings, 1,
					drinkPreferenceWeights, 1f, 0f));
		}

		[Test]
		public void Constructor_ThrowsArgumentNullException_WhenCustomerSharedSettingsIsNull()
		{
			var drinkPreferenceWeights = new Dictionary<IDrinkSettings, float>();
			var random = new RandomStub(new List<double>() { 1f });

			Assert.Throws<ArgumentNullException>(() => new Customer(null, random, null, 1,
					drinkPreferenceWeights, 1f, 0f));
		}

		[Test]
		public void Constructor_ThrowsArgumentException_WhenDrinkRateIsZero()
		{
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
			var drinkPreferenceWeights = new Dictionary<IDrinkSettings, float>();
			var random = new RandomStub(new List<double>() { 1f });

			Assert.Throws<ArgumentException>(() => new Customer(null, random, customerSharedSettings, 1,
					drinkPreferenceWeights, 0f, 0f));
		}

		[Test]
		public void Constructor_ThrowsArgumentException_WhenDrinkRateIsBelowZero()
		{
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
			var drinkPreferenceWeights = new Dictionary<IDrinkSettings, float>();
			var random = new RandomStub(new List<double>() { 1f });

			Assert.Throws<ArgumentException>(() => new Customer(null, random, customerSharedSettings, 1,
					drinkPreferenceWeights, -1f, 0f));
		}

		[Test]
		public void Constructor_ThrowsArgumentException_WhenDrunkennessIsBelowZero()
		{
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
			var drinkPreferenceWeights = new Dictionary<IDrinkSettings, float>();
			var random = new RandomStub(new List<double>() { 1f });

			Assert.Throws<ArgumentException>(() => new Customer(null, random, customerSharedSettings, 1,
					drinkPreferenceWeights, 1f, -1f));
		}

		[Test]
		public void Constructor_ThrowsArgumentException_WhenMoneyIsNegative()
		{
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
			var drinkPreferenceWeights = new Dictionary<IDrinkSettings, float>();
			var random = new RandomStub(new List<double>() { 1f });

			Assert.Throws<ArgumentException>(() => new Customer(null, random, customerSharedSettings, -1,
					drinkPreferenceWeights, 1f, 0f));
		}

		[Test]
		public void Constructor_ThrowsArgumentException_WhenDrunkennessIncreaseMultiplierIsZero()
		{
			var customerSharedSettings = new CustomerSharedSettingsStub(0f, 1f, 1f);
			var drinkPreferenceWeights = new Dictionary<IDrinkSettings, float>();
			var random = new RandomStub(new List<double>() { 1f });

			Assert.Throws<ArgumentException>(() => new Customer(null, random, customerSharedSettings, 1,
					drinkPreferenceWeights, 1f, 0f));
		}

		[Test]
		public void Constructor_ThrowsArgumentException_WhenDrunkennessIncreaseMultiplierIsBelowZero()
		{
			var customerSharedSettings = new CustomerSharedSettingsStub(-1f, 1f, 1f);
			var drinkPreferenceWeights = new Dictionary<IDrinkSettings, float>();
			var random = new RandomStub(new List<double>() { 1f });

			Assert.Throws<ArgumentException>(() => new Customer(null, random, customerSharedSettings, 1,
					drinkPreferenceWeights, 1f, 0f));
		}

		[Test]
		public void Constructor_ThrowsArgumentException_WhenDrunkennessPassedOutThresholdIsZero()
		{
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 0f, 1f);
			var drinkPreferenceWeights = new Dictionary<IDrinkSettings, float>();
			var random = new RandomStub(new List<double>() { 1f });

			Assert.Throws<ArgumentException>(() => new Customer(null, random, customerSharedSettings, 1,
					drinkPreferenceWeights, 1f, 0f));
		}

		[Test]
		public void Constructor_ThrowsArgumentException_WhenDrunkennessPassedOutThresholdIsBelowZero()
		{
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, -1f, 1f);
			var drinkPreferenceWeights = new Dictionary<IDrinkSettings, float>();
			var random = new RandomStub(new List<double>() { 1f });

			Assert.Throws<ArgumentException>(() => new Customer(null, random, customerSharedSettings, 1,
					drinkPreferenceWeights, 1f, 0f));
		}

		[Test]
		public void Constructor_ThrowsArgumentException_WhenDrunkennessPassedOutThresholdIsAboveOne()
		{
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1.1f, 1f);
			var drinkPreferenceWeights = new Dictionary<IDrinkSettings, float>();
			var random = new RandomStub(new List<double>() { 1f });

			Assert.Throws<ArgumentException>(() => new Customer(null, random, customerSharedSettings, 1,
					drinkPreferenceWeights, 1f, 0f));
		}

		[Test]
		public void Constructor_ThrowsArgumentException_WhenDelayBetweenDrinksIsZero()
		{
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 0f);
			var drinkPreferenceWeights = new Dictionary<IDrinkSettings, float>();
			var random = new RandomStub(new List<double>() { 1f });

			Assert.Throws<ArgumentException>(() => new Customer(null, random, customerSharedSettings, 1,
					drinkPreferenceWeights, 1f, 0f));
		}

		[Test]
		public void Constructor_ThrowsArgumentException_WhenDelayBetweenDrinksIsBelowZero()
		{
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, -1f);
			var drinkPreferenceWeights = new Dictionary<IDrinkSettings, float>();
			var random = new RandomStub(new List<double>() { 1f });

			Assert.Throws<ArgumentException>(() => new Customer(null, random, customerSharedSettings, 1,
					drinkPreferenceWeights, 1f, 0f));
		}

		[Test]
		public void Constructor_ThrowsArgumentException_WhenDrinkPreferenceWeightsIsNull()
		{
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
			var random = new RandomStub(new List<double>() { 1f });

			Assert.Throws<ArgumentException>(() => new Customer(null, random, customerSharedSettings, 1, null, 1f, 0f));
		}

		[Test]
		public void Constructor_ThrowsArgumentException_WhenDrinkPreferenceWeightsIsEmpty()
		{
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
			var drinkPreferenceWeights = new Dictionary<IDrinkSettings, float>();
			var random = new RandomStub(new List<double>() { 1f });

			Assert.Throws<ArgumentException>(() => new Customer(null, random, customerSharedSettings, 1,
					drinkPreferenceWeights, 1f, 0f));
		}

		[Test]
		public void Update_ChangesIsPassedOut_WhenDoesHaveDrink()
		{
			var alcoholPercent = 1f;
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, alcoholPercent, 1f);
			var drink1Settings = new DrinkSettingsStub("drink1", 1, alcoholPercent);
			var drinkPreferenceWeights = new Dictionary<IDrinkSettings, float>()
			{
				{ drink1Settings, 1f }
			};
			var random = new RandomStub(new List<double>() { 1f });
			var messenger = new MessengerStub();
			var time = new TimeStub()
			{
				DeltaTime = 1f
			};
			var customer = new Customer(null, random, customerSharedSettings, 1, drinkPreferenceWeights, 1f, 0f);
			customer.Initialize(messenger, time);
			
			messenger.Publish(new CustomerDrinkSaleInitiatedMessage(customer, drink1Settings));
			customer.Update();

			Assert.IsTrue(customer.IsPassedOut);
		}

		[Test]
		public void Update_DoesNotChangeIsPassedOut_WhenDoesNotHaveDrink()
		{
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
			var drinkPreferenceWeights = new Dictionary<IDrinkSettings, float>()
			{
				{ new DrinkSettingsStub("drink1", 1, 1f), 1f }
			};
			var random = new RandomStub(new List<double>() { 1f });
			var messenger = new MessengerStub();
			var time = new TimeStub()
			{
				DeltaTime = 1f
			};
			var customer = new Customer(null, random, customerSharedSettings, 1, drinkPreferenceWeights, 1f, 0f);
			customer.Initialize(messenger, time);

			customer.Update();

			Assert.IsFalse(customer.IsPassedOut);
		}

		[Test]
		public void Update_ChangesIsPassedOut_WhenDrinkRateIsAboveZero()
		{
			var drinkRate = 0.5f;
			var alcoholPercent = 1f;
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, alcoholPercent, 1f);
			var drink1Settings = new DrinkSettingsStub("drink1", 1, alcoholPercent);
			var drinkPreferenceWeights = new Dictionary<IDrinkSettings, float>()
			{
				{ drink1Settings, 1f }
			};
			var random = new RandomStub(new List<double>() { 1f });
			var messenger = new MessengerStub();
			var time = new TimeStub()
			{
				DeltaTime = 1f
			};
			var customer = new Customer(null, random, customerSharedSettings, 1, drinkPreferenceWeights, drinkRate, 0f);
			customer.Initialize(messenger, time);

			messenger.Publish(new CustomerDrinkSaleInitiatedMessage(customer, drink1Settings));
			customer.Update();
			customer.Update();

			Assert.IsTrue(customer.IsPassedOut);
		}

		[Test]
		public void Update_ChangesIsPassedOut_WhenDrinkAlcoholPercentIsAboveZero()
		{
			var alcoholPercent = 1f;
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, alcoholPercent, 1f);
			var drink1Settings = new DrinkSettingsStub("drink1", 1, alcoholPercent);
			var drinkPreferenceWeights = new Dictionary<IDrinkSettings, float>()
			{
				{ drink1Settings, 1f }
			};
			var random = new RandomStub(new List<double>() { 1f });
			var messenger = new MessengerStub();
			var time = new TimeStub()
			{
				DeltaTime = 1f
			};
			var customer = new Customer(null, random, customerSharedSettings, 1, drinkPreferenceWeights, 1f, 0f);
			customer.Initialize(messenger, time);

			messenger.Publish(new CustomerDrinkSaleInitiatedMessage(customer, drink1Settings));
			customer.Update();

			Assert.IsTrue(customer.IsPassedOut);
		}

		[Test]
		public void Update_ChangesIsPassedOut_WhenDrunkennessIncreaseMultiplierIsAboveZero()
		{
			var drunkennessIncreaseMultiplier = 2f;
			var alcoholPercent = 0.5f;
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, alcoholPercent,
					drunkennessIncreaseMultiplier);
			var drink1Settings = new DrinkSettingsStub("drink1", 1, alcoholPercent);
			var drinkPreferenceWeights = new Dictionary<IDrinkSettings, float>()
			{
				{ drink1Settings, 1f }
			};
			var random = new RandomStub(new List<double>() { 1f });
			var messenger = new MessengerStub();
			var time = new TimeStub()
			{
				DeltaTime = 1f
			};
			var customer = new Customer(null, random, customerSharedSettings, 1, drinkPreferenceWeights, 1f, 0f);
			customer.Initialize(messenger, time);

			messenger.Publish(new CustomerDrinkSaleInitiatedMessage(customer, drink1Settings));
			customer.Update();

			Assert.IsTrue(customer.IsPassedOut);
		}

		[Test]
		public void Update_ChangesIsPassedOut_WhenAmountLeftInDrinkIsAboveZero()
		{
			var drinkCost = 1;
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
			var drink1Settings = new DrinkSettingsStub("drink1", drinkCost, 1f);
			var drinkPreferenceWeights = new Dictionary<IDrinkSettings, float>()
			{
				{ drink1Settings, 1f }
			};
			var random = new RandomStub(new List<double>() { 1f });
			var messenger = new MessengerStub();
			var time = new TimeStub()
			{
				DeltaTime = 1f
			};
			var customer = new Customer(null, random, customerSharedSettings, drinkCost, drinkPreferenceWeights, 1f, 0f);
			customer.Initialize(messenger, time);

			messenger.Publish(new CustomerDrinkSaleInitiatedMessage(customer, drink1Settings));
			customer.Update();

			Assert.IsTrue(customer.IsPassedOut);
		}

		[Test]
		public void Update_PublishesDrinkFillAmountChangedMessage_WhenHasDrink()
		{
			var drinkCost = 1;
			var delayBetweenDrinks = 1f;
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, delayBetweenDrinks);
			var drink1Settings = new DrinkSettingsStub("drink1", drinkCost, 0f);
			var drinkPreferenceWeights = new Dictionary<IDrinkSettings, float>()
			{
				{ drink1Settings, 1f }
			};
			var random = new RandomStub(new List<double>() { 1f });
			var messenger = new MessengerStub();
			var time = new TimeStub()
			{
				DeltaTime = 1f,
				Time = delayBetweenDrinks
			};
			var customer = new Customer(null, random, customerSharedSettings, drinkCost, drinkPreferenceWeights, 1f, 0f);
			customer.Initialize(messenger, time);
			var drinkFillAmountChangedMessageSubscriberStub =
					new DrinkFillAmountChangedMessageSubscriberStub(messenger);

			messenger.Publish(new CustomerDrinkSaleInitiatedMessage(customer, drink1Settings));
			customer.Update();

			Assert.IsNotNull(drinkFillAmountChangedMessageSubscriberStub.Message);
		}

		[Test]
		public void Update_DoesNotPublishDrinkFillAmountChangedMessage_WhenDoesNotHaveDrink()
		{
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
			var drinkPreferenceWeights = new Dictionary<IDrinkSettings, float>()
			{
				{ new DrinkSettingsStub("drink1", 1, 1f), 1f }
			};
			var random = new RandomStub(new List<double>() { 1f });
			var messenger = new MessengerStub();
			var time = new TimeStub()
			{
				DeltaTime = 1f
			};
			var customer = new Customer(null, random, customerSharedSettings, 1, drinkPreferenceWeights, 1f, 0f);
			customer.Initialize(messenger, time);
			var drinkFillAmountChangedMessageSubscriberStub = new DrinkFillAmountChangedMessageSubscriberStub(messenger);

			customer.Update();

			Assert.IsNull(drinkFillAmountChangedMessageSubscriberStub.Message);
		}

		[Test]
		public void Update_AmountDrankIsAffectedByDrinkRate_WhenDrinkRateIsAboveZero()
		{
			var drinkRate = 0.5f;
			var drinkCost = 1;
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
			var drink1Settings = new DrinkSettingsStub("drink1", drinkCost, 1f);
			var drinkPreferenceWeights = new Dictionary<IDrinkSettings, float>()
			{
				{ drink1Settings, 1f }
			};
			var random = new RandomStub(new List<double>() { 1f });
			var messenger = new MessengerStub();
			var time = new TimeStub()
			{
				DeltaTime = 1f
			};
			var customer = new Customer(null, random, customerSharedSettings, drinkCost, drinkPreferenceWeights,
					drinkRate, 0f);
			customer.Initialize(messenger, time);
			var drinkFillAmountChangedMessageSubscriberStub =
					new DrinkFillAmountChangedMessageSubscriberStub(messenger);

			messenger.Publish(new CustomerDrinkSaleInitiatedMessage(customer, drink1Settings));
			customer.Update();

			Assert.AreEqual(0.5f, drinkFillAmountChangedMessageSubscriberStub.Message.FillAmount);
		}

		[Test]
		public void Update_AmountDrankIsAffectedByDrinkRate_WhenDeltaTimeIsAboveZero()
		{
			var drinkRate = 1f;
			var drinkCost = 1;
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
			var drink1Settings = new DrinkSettingsStub("drink1", drinkCost, 1f);
			var drinkPreferenceWeights = new Dictionary<IDrinkSettings, float>()
			{
				{ drink1Settings, 1f }
			};
			var random = new RandomStub(new List<double>() { 1f });
			var messenger = new MessengerStub();
			var time = new TimeStub()
			{
				DeltaTime = 0.5f,
				Time = 1f
			};
			var customer = new Customer(null, random, customerSharedSettings, drinkCost, drinkPreferenceWeights,
					drinkRate, 0f);
			customer.Initialize(messenger, time);
			var drinkFillAmountChangedMessageSubscriberStub =
					new DrinkFillAmountChangedMessageSubscriberStub(messenger);

			messenger.Publish(new CustomerDrinkSaleInitiatedMessage(customer, drink1Settings));
			customer.Update();

			Assert.AreEqual(0.5f, drinkFillAmountChangedMessageSubscriberStub.Message.FillAmount);
		}

		[Test]
		public void Update_DoesNotPublishCustomerNewDrinkRequestedMessage_WhenHasDrink()
		{
			var drinkCost = 1;
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
			var drink1Settings = new DrinkSettingsStub("drink1", drinkCost, 1f);
			var drinkPreferenceWeights = new Dictionary<IDrinkSettings, float>()
			{
				{ drink1Settings, 1f }
			};
			var random = new RandomStub(new List<double>() { 1f });
			var messenger = new MessengerStub();
			var time = new TimeStub()
			{
				DeltaTime = 1f
			};
			var customer = new Customer(null, random, customerSharedSettings, drinkCost, drinkPreferenceWeights, 1f, 0f);
			customer.Initialize(messenger, time);
			var customerNewDrinkRequestedMessageSubscriberStub =
					new CustomerNewDrinkRequestedMessageSubscriberStub(messenger);

			customer.Update();
			messenger.Publish(new CustomerDrinkSaleInitiatedMessage(customer, drink1Settings));
			customerNewDrinkRequestedMessageSubscriberStub.Message = null;
			customer.Update();

			Assert.IsNull(customerNewDrinkRequestedMessageSubscriberStub.Message);
		}

		[Test]
		public void Update_DoesNotPublishCustomerNewDrinkRequestedMessage_WhenIsPassedOut()
		{
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
			var drinkPreferenceWeights = new Dictionary<IDrinkSettings, float>()
			{
				{ new DrinkSettingsStub("drink1", 1, 1f), 1f }
			};
			var random = new RandomStub(new List<double>() { 1f });
			var messenger = new MessengerStub();
			var time = new TimeStub()
			{
				DeltaTime = 1f
			};
			var customer = new Customer(null, random, customerSharedSettings, 1, drinkPreferenceWeights, 1f,
					customerSharedSettings.DrunkennessPassedOutThreshold);
			customer.Initialize(messenger, time);
			var customerNewDrinkRequestedMessageSubscriberStub =
					new CustomerNewDrinkRequestedMessageSubscriberStub(messenger);

			customer.Update();

			Assert.IsNull(customerNewDrinkRequestedMessageSubscriberStub.Message);
		}

		[Test]
		public void Update_DoesNotPublishCustomerNewDrinkRequestedMessage_WhenDrinkWasFinishedTooRecently()
		{
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
			var drinkPreferenceWeights = new Dictionary<IDrinkSettings, float>()
			{
				{ new DrinkSettingsStub("drink1", 1, 0f), 1f }
			};
			var random = new RandomStub(new List<double>() { 1f });
			var messenger = new MessengerStub();
			var time = new TimeStub()
			{
				DeltaTime = 1f,
				Time = 0f
			};
			var customer = new Customer(null, random, customerSharedSettings, 1, drinkPreferenceWeights, 1f, 0f);
			customer.Initialize(messenger, time);
			var customerNewDrinkRequestedMessageSubscriberStub =
					new CustomerNewDrinkRequestedMessageSubscriberStub(messenger);

			customer.Update();

			Assert.IsNull(customerNewDrinkRequestedMessageSubscriberStub.Message);
		}

		[Test]
		public void Update_DoesNotPublishCustomerNewDrinkRequestedMessage_WhenCustomerAlreadyRequestedDrink()
		{
			var delayBetweenDrinks = 1f;
			var drinkCost = 1;
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, delayBetweenDrinks);
			var drinkPreferenceWeights = new Dictionary<IDrinkSettings, float>()
			{
				{ new DrinkSettingsStub("drink1", drinkCost, 1f), 1f }
			};
			var random = new RandomStub(new List<double>() { 1f });
			var messenger = new MessengerStub();
			var time = new TimeStub()
			{
				DeltaTime = 1f,
				Time = delayBetweenDrinks
			};
			var customer = new Customer(null, random, customerSharedSettings, drinkCost * 2, drinkPreferenceWeights,
					1f, 0f);
			customer.Initialize(messenger, time);
			var customerNewDrinkRequestedMessageSubscriberStub =
					new CustomerNewDrinkRequestedMessageSubscriberStub(messenger);

			customer.Update();
			customer.Update();
			customerNewDrinkRequestedMessageSubscriberStub.Message = null;
			customer.Update();

			Assert.IsNull(customerNewDrinkRequestedMessageSubscriberStub.Message);
		}

		[Test]
		public void Update_PublishesCustomerNewDrinkRequestedMessage_WhenHasNoDrinkAndIsNotPassedOutAndDrinkWasNotFinishedTooRecentlyAndCustomerDidNotAlreadyRequestDrink()
		{
			var delayBetweenDrinks = 1f;
			var drinkCost = 1;
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, delayBetweenDrinks);
			var drinkPreferenceWeights = new Dictionary<IDrinkSettings, float>()
			{
				{ new DrinkSettingsStub("drink1", drinkCost, 1f), 1f }
			};
			var random = new RandomStub(new List<double>() { 1f });
			var messenger = new MessengerStub();
			var time = new TimeStub()
			{
				DeltaTime = 1f,
				Time = delayBetweenDrinks
			};
			var customer = new Customer(null, random, customerSharedSettings, drinkCost, drinkPreferenceWeights, 1f, 0f);
			customer.Initialize(messenger, time);
			var customerNewDrinkRequestedMessageSubscriberStub =
					new CustomerNewDrinkRequestedMessageSubscriberStub(messenger);

			customer.Update();

			Assert.IsNotNull(customerNewDrinkRequestedMessageSubscriberStub.Message);
		}

		[Test]
		public void Update_RequestedDrinkIsRandomlySelected_WhenOtherPrerequisitsAreMet_AndDrinkPreferenceWeightsAreNormalized()
		{
			var delayBetweenDrinks = 1f;
			var drinkCost = 1;
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, delayBetweenDrinks);
			var drink1Settings = new DrinkSettingsStub("drink1", drinkCost, 1f);
			var drink2Settings = new DrinkSettingsStub("drink2", drinkCost, 1f);
			var drinkPreferenceWeights = new Dictionary<IDrinkSettings, float>()
			{
				{ drink1Settings, 1f },
				{ drink2Settings, 1f }
			};
			var randomValues = new List<double>() { 0D, 1D };
			var expectedDrinkSettings = new List<IDrinkSettings>() { drink1Settings, drink2Settings };
			var messenger = new MessengerStub();

			for(int i = 0; i < randomValues.Count; i++)
			{
				var random = new RandomStub(new List<double>() { randomValues[i] });
				var time = new TimeStub()
				{
					DeltaTime = 1f,
					Time = delayBetweenDrinks
				};
				var customer = new Customer(null, random, customerSharedSettings, drinkCost, drinkPreferenceWeights,
						1f, 0f);
				customer.Initialize(messenger, time);
				var customerNewDrinkRequestedMessageSubscriberStub =
						new CustomerNewDrinkRequestedMessageSubscriberStub(messenger);

				customer.Update();

				Assert.AreEqual(expectedDrinkSettings[i],
						customerNewDrinkRequestedMessageSubscriberStub.Message.DrinkSettings);
			}
		}

		[Test]
		public void Update_RequestedDrinkIsRandomlySelected_WhenOtherPrerequisitsAreMet_AndDrinkPreferenceWeightsAreNotNormalized()
		{
			var delayBetweenDrinks = 1f;
			var drinkCost = 1;
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, delayBetweenDrinks);
			var drink1Settings = new DrinkSettingsStub("drink1", drinkCost, 1f);
			var drink2Settings = new DrinkSettingsStub("drink2", drinkCost, 1f);
			var drink1Weight = 2f;
			var drink2Weight = 1f;
			var drinkPreferenceWeights = new Dictionary<IDrinkSettings, float>()
			{
				{ drink1Settings, drink1Weight },
				{ drink2Settings, drink2Weight }
			};
			var randomValues = new List<double>() { 0D, 1D };
			var expectedDrinkSettings = new List<IDrinkSettings>() { drink1Settings, drink2Settings };
			var messenger = new MessengerStub();

			for(int i = 0; i < randomValues.Count; i++)
			{
				var random = new RandomStub(new List<double>() { randomValues[i] });
				var time = new TimeStub()
				{
					DeltaTime = 1f,
					Time = delayBetweenDrinks
				};
				var customer = new Customer(null, random, customerSharedSettings, drinkCost, drinkPreferenceWeights,
						1f, 0f);
				customer.Initialize(messenger, time);
				var customerNewDrinkRequestedMessageSubscriberStub =
						new CustomerNewDrinkRequestedMessageSubscriberStub(messenger);

				customer.Update();

				UnityEngine.Debug.Log(expectedDrinkSettings[i].Name + ", " +
						customerNewDrinkRequestedMessageSubscriberStub.Message.DrinkSettings.Name);
				Assert.AreEqual(expectedDrinkSettings[i],
						customerNewDrinkRequestedMessageSubscriberStub.Message.DrinkSettings);
			}
		}

		[Test]
		public void Update_BasesWhenToRequestNewDrinkOnTimeLastDrinkWasFinished_WhenOtherPrerequisitsAreMet()
		{
			var delayBetweenDrinks = 1f;
			var drinkCost = 1;
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, delayBetweenDrinks);
			var drinkSettings = new DrinkSettingsStub("drink1", drinkCost, 0f);
			var drinkPreferenceWeights = new Dictionary<IDrinkSettings, float>()
			{
				{ drinkSettings, 1f }
			};
			var random = new RandomStub(new List<double>() { 1f });
			var messenger = new MessengerStub();
			var time = new TimeStub()
			{
				DeltaTime = 1f,
				Time = delayBetweenDrinks
			};
			var customer = new Customer(null, random, customerSharedSettings, drinkCost, drinkPreferenceWeights, 1f, 0f);
			customer.Initialize(messenger, time);
			var customerNewDrinkRequestedMessageSubscriberStub =
					new CustomerNewDrinkRequestedMessageSubscriberStub(messenger);
			var customerDrinkSaleInitiatedMessagePublisherStub =
					new CustomerDrinkSaleInitiatedMessagePublisherStub(messenger);

			customerDrinkSaleInitiatedMessagePublisherStub.Publish(
					new CustomerDrinkSaleInitiatedMessage(customer, drinkSettings));
			customer.Update();
			time.Step(delayBetweenDrinks);
			customerNewDrinkRequestedMessageSubscriberStub.Message = null;
			customer.Update();

			Assert.IsNotNull(customerNewDrinkRequestedMessageSubscriberStub.Message);
		}

		[Test]
		public void PublishesCustomerDrinkSoldMessage_WhenHasNoDrinkAndHasEnoughMoney()
		{
			var delayBetweenDrinks = 1f;
			var drinkCost = 1;
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, delayBetweenDrinks);
			var drinkSettings = new DrinkSettingsStub("drink1", drinkCost, 1f);
			var drinkPreferenceWeights = new Dictionary<IDrinkSettings, float>()
			{
				{ drinkSettings, 1f }
			};
			var random = new RandomStub(new List<double>() { 1f });
			var messenger = new MessengerStub();
			var time = new TimeStub()
			{
				DeltaTime = 1f,
				Time = delayBetweenDrinks
			};
			var customer = new Customer(null, random, customerSharedSettings, drinkCost, drinkPreferenceWeights,
					1f, 0f);
			customer.Initialize(messenger, time);
			var customerDrinkSaleInitiatedMessagePublisherStub =
					new CustomerDrinkSaleInitiatedMessagePublisherStub(messenger);
			var customerDrinkSoldMessageSubscriberStub = new CustomerDrinkSoldMessageSubscriberStub(messenger);

			customerDrinkSaleInitiatedMessagePublisherStub.Publish(new CustomerDrinkSaleInitiatedMessage(customer,
					drinkSettings));

			Assert.IsNotNull(customerDrinkSoldMessageSubscriberStub.Message);
		}

		[Test]
		public void DoesNotPublishCustomerDrinkSoldMessage_WhenHasDrink()
		{
			var delayBetweenDrinks = 1f;
			var drinkCost = 1;
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, delayBetweenDrinks);
			var drinkSettings = new DrinkSettingsStub("drink1", drinkCost, 1f);
			var drinkPreferenceWeights = new Dictionary<IDrinkSettings, float>()
			{
				{ drinkSettings, 1f }
			};
			var random = new RandomStub(new List<double>() { 1f });
			var messenger = new MessengerStub();
			var time = new TimeStub()
			{
				DeltaTime = 1f,
				Time = delayBetweenDrinks
			};
			var customer = new Customer(null, random, customerSharedSettings, drinkCost * 2, drinkPreferenceWeights,
					1f, 0f);
			customer.Initialize(messenger, time);
			var customerDrinkSaleInitiatedMessagePublisherStub =
					new CustomerDrinkSaleInitiatedMessagePublisherStub(messenger);
			var customerDrinkSoldMessageSubscriberStub = new CustomerDrinkSoldMessageSubscriberStub(messenger);

			customerDrinkSaleInitiatedMessagePublisherStub.Publish(
					new CustomerDrinkSaleInitiatedMessage(customer, drinkSettings));
			customerDrinkSoldMessageSubscriberStub.Message = null;
			customerDrinkSaleInitiatedMessagePublisherStub.Publish(
					new CustomerDrinkSaleInitiatedMessage(customer, drinkSettings));

			Assert.IsNull(customerDrinkSoldMessageSubscriberStub.Message);
		}

		[Test]
		public void DoesNotPublishCustomerDrinkSoldMessage_WhenDoesNotHaveEnoughMoney()
		{
			var delayBetweenDrinks = 1f;
			var drinkCost = 1;
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, delayBetweenDrinks);
			var drinkSettings = new DrinkSettingsStub("drink1", drinkCost, 1f);
			var drinkPreferenceWeights = new Dictionary<IDrinkSettings, float>()
			{
				{ drinkSettings, 1f }
			};
			var random = new RandomStub(new List<double>() { 1f });
			var messenger = new MessengerStub();
			var time = new TimeStub()
			{
				DeltaTime = 1f,
				Time = delayBetweenDrinks
			};
			var customer = new Customer(null, random, customerSharedSettings, drinkCost / 2, drinkPreferenceWeights,
					1f, 0f);
			customer.Initialize(messenger, time);
			var customerDrinkSaleInitiatedMessagePublisherStub =
					new CustomerDrinkSaleInitiatedMessagePublisherStub(messenger);
			var customerDrinkSoldMessageSubscriberStub = new CustomerDrinkSoldMessageSubscriberStub(messenger);

			customerDrinkSaleInitiatedMessagePublisherStub.Publish(
					new CustomerDrinkSaleInitiatedMessage(customer, drinkSettings));

			Assert.IsNull(customerDrinkSoldMessageSubscriberStub.Message);
		}
	}
}
