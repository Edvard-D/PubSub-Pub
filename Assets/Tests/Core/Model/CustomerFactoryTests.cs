using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PubSubPub.Game.Core.Messages;
using PubSubPub.Game.Core.Model;
using PubSubPub.Tests.Stubs;
using PubSubPub.Tests.Stubs.Core.Model;
using PubSubPub.Tests.Stubs.Messages;

namespace PubSubPub.Tests.Core.Model
{
	public class CustomerFactoryTests
	{
		[Test]
		public void Constructor_ThrowsArgumentNullException_WhenMessengerIsNull()
		{
			var random = new RandomStub();
			var time = new TimeStub();
			var customerInstantiationSettings = new CustomerInstantiationSettingsStub
			{
				DrinkRateMin = 1f,
				DrinkRateMax = 1f,
				StartingMoneyMin = 1,
				StartingMoneyMax = 1
			};
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
			var drinkSettings = new List<IDrinkSettings>()
			{
				new DrinkSettingsStub("drink1", 1, 1f)
			};

			Assert.Throws<ArgumentNullException>(() => new CustomerFactory(null, random, time,
					customerInstantiationSettings, customerSharedSettings, drinkSettings));
		}

		[Test]
		public void Constructor_ThrowsArgumentNullException_WhenRandomIsNull()
		{
			var messenger = new MessengerStub();
			var time = new TimeStub();
			var customerInstantiationSettings = new CustomerInstantiationSettingsStub
			{
				DrinkRateMin = 1f,
				DrinkRateMax = 1f,
				StartingMoneyMin = 1,
				StartingMoneyMax = 1
			};
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
			var drinkSettings = new List<IDrinkSettings>()
			{
				new DrinkSettingsStub("drink1", 1, 1f)
			};

			Assert.Throws<ArgumentNullException>(() => new CustomerFactory(messenger, null, time,
					customerInstantiationSettings, customerSharedSettings, drinkSettings));
		}

		[Test]
		public void Constructor_ThrowsArgumentNullException_WhenTimeIsNull()
		{
			var messenger = new MessengerStub();
			var random = new RandomStub();
			var customerInstantiationSettings = new CustomerInstantiationSettingsStub
			{
				DrinkRateMin = 1f,
				DrinkRateMax = 1f,
				StartingMoneyMin = 1,
				StartingMoneyMax = 1
			};
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
			var drinkSettings = new List<IDrinkSettings>()
			{
				new DrinkSettingsStub("drink1", 1, 1f)
			};

			Assert.Throws<ArgumentNullException>(() => new CustomerFactory(messenger, random, null,
					customerInstantiationSettings, customerSharedSettings, drinkSettings));
		}

		[Test]
		public void Constructor_ThrowsArgumentNullException_WhenCustomerInstantiationSettingsIsNull()
		{
			var messenger = new MessengerStub();
			var random = new RandomStub();
			var time = new TimeStub();
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
			var drinkSettings = new List<IDrinkSettings>()
			{
				new DrinkSettingsStub("drink1", 1, 1f)
			};

			Assert.Throws<ArgumentNullException>(() => new CustomerFactory(messenger, random, time,
					null, customerSharedSettings, drinkSettings));
		}

		[Test]
		public void Constructor_ThrowsArgumentNullException_WhenCustomerSharedSettingsIsNull()
		{
			var messenger = new MessengerStub();
			var random = new RandomStub();
			var time = new TimeStub();
			var customerInstantiationSettings = new CustomerInstantiationSettingsStub
			{
				DrinkRateMin = 1f,
				DrinkRateMax = 1f,
				StartingMoneyMin = 1,
				StartingMoneyMax = 1
			};
			var drinkSettings = new List<IDrinkSettings>()
			{
				new DrinkSettingsStub("drink1", 1, 1f)
			};

			Assert.Throws<ArgumentNullException>(() => new CustomerFactory(messenger, random, time,
					customerInstantiationSettings, null, drinkSettings));
		}

		[Test]
		public void Constructor_ThrowsArgumentException_WhenDrinkSettingsIsNull()
		{
			var messenger = new MessengerStub();
			var random = new RandomStub();
			var time = new TimeStub();
			var customerInstantiationSettings = new CustomerInstantiationSettingsStub
			{
				DrinkRateMin = 1f,
				DrinkRateMax = 1f,
				StartingMoneyMin = 1,
				StartingMoneyMax = 1
			};
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);

			Assert.Throws<ArgumentException>(() => new CustomerFactory(messenger, random, time,
					customerInstantiationSettings, customerSharedSettings, null));
		}

		[Test]
		public void Constructor_ThrowsArgumentException_WhenDrinkSettingsIsEmpty()
		{
			var messenger = new MessengerStub();
			var random = new RandomStub();
			var time = new TimeStub();
			var customerInstantiationSettings = new CustomerInstantiationSettingsStub
			{
				DrinkRateMin = 1f,
				DrinkRateMax = 1f,
				StartingMoneyMin = 1,
				StartingMoneyMax = 1
			};
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
			var drinkSettings = new List<IDrinkSettings>();

			Assert.Throws<ArgumentException>(() => new CustomerFactory(messenger, random, time,
					customerInstantiationSettings, customerSharedSettings, drinkSettings));
		}

		[Test]
		public void Constructor_ThrowsArgumentException_WhenCustomerStartingMoneyMinIsLessThanZero()
		{
			var messenger = new MessengerStub();
			var random = new RandomStub();
			var time = new TimeStub();
			var customerInstantiationSettings = new CustomerInstantiationSettingsStub
			{
				DrinkRateMin = 1f,
				DrinkRateMax = 1f,
				StartingMoneyMin = -1,
				StartingMoneyMax = 1
			};
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
			var drinkSettings = new List<IDrinkSettings>()
			{
				new DrinkSettingsStub("drink1", 1, 1f)
			};

			Assert.Throws<ArgumentException>(() => new CustomerFactory(messenger, random, time,
					customerInstantiationSettings, customerSharedSettings, drinkSettings));
		}

		[Test]
		public void Constructor_ThrowsArgumentException_WhenCustomerStartingMoneyMaxIsLessThanZero()
		{
			var messenger = new MessengerStub();
			var random = new RandomStub();
			var time = new TimeStub();
			var customerInstantiationSettings = new CustomerInstantiationSettingsStub
			{
				DrinkRateMin = 1f,
				DrinkRateMax = 1f,
				StartingMoneyMin = 1,
				StartingMoneyMax = -1
			};
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
			var drinkSettings = new List<IDrinkSettings>()
			{
				new DrinkSettingsStub("drink1", 1, 1f)
			};

			Assert.Throws<ArgumentException>(() => new CustomerFactory(messenger, random, time,
					customerInstantiationSettings, customerSharedSettings, drinkSettings));
		}

		[Test]
		public void Constructor_DoesNotThrowArgumentException_WhenCustomerStartingMoneyMinIsEqualToZero()
		{
			var messenger = new MessengerStub();
			var random = new RandomStub();
			var time = new TimeStub();
			var customerInstantiationSettings = new CustomerInstantiationSettingsStub
			{
				DrinkRateMin = 1f,
				DrinkRateMax = 1f,
				StartingMoneyMin = 0,
				StartingMoneyMax = 1
			};
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
			var drinkSettings = new List<IDrinkSettings>()
			{
				new DrinkSettingsStub("drink1", 1, 1f)
			};

			Assert.DoesNotThrow(() => new CustomerFactory(messenger, random, time, customerInstantiationSettings,
					customerSharedSettings, drinkSettings));
		}

		[Test]
		public void Constructor_DoesNotThrowArgumentException_WhenCustomerStartingMoneyMaxIsEqualToZero()
		{
			var messenger = new MessengerStub();
			var random = new RandomStub();
			var time = new TimeStub();
			var customerInstantiationSettings = new CustomerInstantiationSettingsStub
			{
				DrinkRateMin = 1f,
				DrinkRateMax = 1f,
				StartingMoneyMin = 0,
				StartingMoneyMax = 0
			};
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
			var drinkSettings = new List<IDrinkSettings>()
			{
				new DrinkSettingsStub("drink1", 1, 1f)
			};

			Assert.DoesNotThrow(() => new CustomerFactory(messenger, random, time, customerInstantiationSettings,
					customerSharedSettings, drinkSettings));
		}

		[Test]
		public void Constructor_DoesNotThrowArgumentException_WhenCustomerStartingMoneyMinIsLessThanCustomerStartingMoneyMax()
		{
			var messenger = new MessengerStub();
			var random = new RandomStub();
			var time = new TimeStub();
			var customerInstantiationSettings = new CustomerInstantiationSettingsStub
			{
				DrinkRateMin = 1f,
				DrinkRateMax = 1f,
				StartingMoneyMin = 1,
				StartingMoneyMax = 2
			};
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
			var drinkSettings = new List<IDrinkSettings>()
			{
				new DrinkSettingsStub("drink1", 1, 1f)
			};

			Assert.DoesNotThrow(() => new CustomerFactory(messenger, random, time, customerInstantiationSettings,
					customerSharedSettings, drinkSettings));
		}

		[Test]
		public void Constructor_ThrowsArgumentException_WhenCustomerStartingMoneyMinIsGreaterThanCustomerStartingMoneyMax()
		{
			var messenger = new MessengerStub();
			var random = new RandomStub();
			var time = new TimeStub();
			var customerInstantiationSettings = new CustomerInstantiationSettingsStub
			{
				DrinkRateMin = 1f,
				DrinkRateMax = 1f,
				StartingMoneyMin = 2,
				StartingMoneyMax = 1
			};
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
			var drinkSettings = new List<IDrinkSettings>()
			{
				new DrinkSettingsStub("drink1", 1, 1f)
			};

			Assert.Throws<ArgumentException>(() => new CustomerFactory(messenger, random, time,
					customerInstantiationSettings, customerSharedSettings, drinkSettings));
		}

		[Test]
		public void Constructor_DoesNotThrowArgumentException_WhenCustomerStartingMoneyMinIsEqualToCustomerStartingMoneyMax()
		{
			var messenger = new MessengerStub();
			var random = new RandomStub();
			var time = new TimeStub();
			var customerInstantiationSettings = new CustomerInstantiationSettingsStub
			{
				DrinkRateMin = 1f,
				DrinkRateMax = 1f,
				StartingMoneyMin = 1,
				StartingMoneyMax = 1
			};
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
			var drinkSettings = new List<IDrinkSettings>()
			{
				new DrinkSettingsStub("drink1", 1, 1f)
			};

			Assert.DoesNotThrow(() => new CustomerFactory(messenger, random, time, customerInstantiationSettings,
					customerSharedSettings, drinkSettings));
		}

		[Test]
		public void Constructor_ThrowsArgumentException_WhenCustomerStartingDrunkennessMaxIsLessThanZero()
		{
			var messenger = new MessengerStub();
			var random = new RandomStub();
			var time = new TimeStub();
			var customerInstantiationSettings = new CustomerInstantiationSettingsStub
			{
				DrinkRateMin = 1f,
				DrinkRateMax = 1f,
				StartingDrunkennessMax = -1
			};
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
			var drinkSettings = new List<IDrinkSettings>()
			{
				new DrinkSettingsStub("drink1", 1, 1f)
			};

			Assert.Throws<ArgumentException>(() => new CustomerFactory(messenger, random, time,
					customerInstantiationSettings, customerSharedSettings, drinkSettings));
		}

		[Test]
		public void Constructor_DoesNotThrowArgumentException_WhenCustomerStartingDrunkennessMaxIsEqualToZero()
		{
			var messenger = new MessengerStub();
			var random = new RandomStub();
			var time = new TimeStub();
			var customerInstantiationSettings = new CustomerInstantiationSettingsStub
			{
				DrinkRateMin = 1f,
				DrinkRateMax = 1f,
				StartingDrunkennessMax = 0
			};
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
			var drinkSettings = new List<IDrinkSettings>()
			{
				new DrinkSettingsStub("drink1", 1, 1f)
			};

			Assert.DoesNotThrow(() => new CustomerFactory(messenger, random, time, customerInstantiationSettings,
					customerSharedSettings, drinkSettings));
		}

		[Test]
		public void Constructor_DoesNotThrowArgumentException_WhenCustomerStartingDrunkennessMaxIsGreaterThanZero()
		{
			var messenger = new MessengerStub();
			var random = new RandomStub();
			var time = new TimeStub();
			var customerInstantiationSettings = new CustomerInstantiationSettingsStub
			{
				DrinkRateMin = 1f,
				DrinkRateMax = 1f,
				StartingDrunkennessMax = 1f
			};
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
			var drinkSettings = new List<IDrinkSettings>()
			{
				new DrinkSettingsStub("drink1", 1, 1f)
			};

			Assert.DoesNotThrow(() => new CustomerFactory(messenger, random, time, customerInstantiationSettings,
					customerSharedSettings, drinkSettings));
		}

		[Test]
		public void Constructor_ThrowsArgumentException_WhenCustomerDrinkRateMinIsLessThanZero()
		{
			var messenger = new MessengerStub();
			var random = new RandomStub();
			var time = new TimeStub();
			var customerInstantiationSettings = new CustomerInstantiationSettingsStub
			{
				DrinkRateMin = -1f,
				DrinkRateMax = 1f,
				StartingDrunkennessMax = 1f
			};
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
			var drinkSettings = new List<IDrinkSettings>()
			{
				new DrinkSettingsStub("drink1", 1, 1f)
			};

			Assert.Throws<ArgumentException>(() => new CustomerFactory(messenger, random, time,
					customerInstantiationSettings, customerSharedSettings, drinkSettings));
		}

		[Test]
		public void Constructor_ThrowsArgumentException_WhenCustomerDrinkRateMinIsEqualToZero()
		{
			var messenger = new MessengerStub();
			var random = new RandomStub();
			var time = new TimeStub();
			var customerInstantiationSettings = new CustomerInstantiationSettingsStub
			{
				DrinkRateMin = 0f,
				DrinkRateMax = 1f,
				StartingDrunkennessMax = 1f
			};
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
			var drinkSettings = new List<IDrinkSettings>()
			{
				new DrinkSettingsStub("drink1", 1, 1f)
			};

			Assert.Throws<ArgumentException>(() => new CustomerFactory(messenger, random, time,
					customerInstantiationSettings, customerSharedSettings, drinkSettings));
		}

		[Test]
		public void Constructor_DoesNotThrowArgumentException_WhenCustomerDrinkRateMinIsGreaterThanZero()
		{
			var messenger = new MessengerStub();
			var random = new RandomStub();
			var time = new TimeStub();
			var customerInstantiationSettings = new CustomerInstantiationSettingsStub
			{
				DrinkRateMin = 1f,
				DrinkRateMax = 1f,
				StartingDrunkennessMax = 1f
			};
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
			var drinkSettings = new List<IDrinkSettings>()
			{
				new DrinkSettingsStub("drink1", 1, 1f)
			};

			Assert.DoesNotThrow(() => new CustomerFactory(messenger, random, time, customerInstantiationSettings,
					customerSharedSettings, drinkSettings));
		}

		[Test]
		public void Constructor_ThrowsArgumentException_WhenCustomerDrinkRateMaxIsLessThanZero()
		{
			var messenger = new MessengerStub();
			var random = new RandomStub();
			var time = new TimeStub();
			var customerInstantiationSettings = new CustomerInstantiationSettingsStub
			{
				DrinkRateMin = 1f,
				DrinkRateMax = -1f,
				StartingDrunkennessMax = 1f
			};
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
			var drinkSettings = new List<IDrinkSettings>()
			{
				new DrinkSettingsStub("drink1", 1, 1f)
			};

			Assert.Throws<ArgumentException>(() => new CustomerFactory(messenger, random, time,
					customerInstantiationSettings, customerSharedSettings, drinkSettings));
		}

		[Test]
		public void Constructor_ThrowsArgumentExceptionWhenCustomerDrinkRateMaxIsEqualToZero()
		{
			var messenger = new MessengerStub();
			var random = new RandomStub();
			var time = new TimeStub();
			var customerInstantiationSettings = new CustomerInstantiationSettingsStub
			{
				DrinkRateMin = 1f,
				DrinkRateMax = 0f,
				StartingDrunkennessMax = 1f
			};
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
			var drinkSettings = new List<IDrinkSettings>()
			{
				new DrinkSettingsStub("drink1", 1, 1f)
			};

			Assert.Throws<ArgumentException>(() => new CustomerFactory(messenger, random, time,
					customerInstantiationSettings, customerSharedSettings, drinkSettings));
		}

		[Test]
		public void Constructor_DoesNotThrowArgumentException_WhenCustomerDrinkRateMaxIsGreaterThanZero()
		{
			var messenger = new MessengerStub();
			var random = new RandomStub();
			var time = new TimeStub();
			var customerInstantiationSettings = new CustomerInstantiationSettingsStub
			{
				DrinkRateMin = 1f,
				DrinkRateMax = 1f,
				StartingDrunkennessMax = 1f
			};
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
			var drinkSettings = new List<IDrinkSettings>()
			{
				new DrinkSettingsStub("drink1", 1, 1f)
			};

			Assert.DoesNotThrow(() => new CustomerFactory(messenger, random, time, customerInstantiationSettings,
					customerSharedSettings, drinkSettings));
		}

		[Test]
		public void Constructor_ThrowsArgumentException_WhenCustomerDrinkRateMinIsGreaterThanCustomerDrinkRateMax()
		{
			var messenger = new MessengerStub();
			var random = new RandomStub();
			var time = new TimeStub();
			var customerInstantiationSettings = new CustomerInstantiationSettingsStub
			{
				DrinkRateMin = 2f,
				DrinkRateMax = 1f,
				StartingDrunkennessMax = 1f
			};
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
			var drinkSettings = new List<IDrinkSettings>()
			{
				new DrinkSettingsStub("drink1", 1, 1f)
			};

			Assert.Throws<ArgumentException>(() => new CustomerFactory(messenger, random, time,
					customerInstantiationSettings, customerSharedSettings, drinkSettings));
		}

		[Test]
		public void PublishesCustomerInstantiatedMessage_WhenCustomerInstantiateRequestedMessageIsPublished()
		{
			var messenger = new MessengerStub();
			var random = new RandomStub()
			{
				RandomDoubleValues = new List<double>() { 0.5, 0.5, 0.5 },
				RandomIntValues = new List<int>() { 0 }
			};
			var time = new TimeStub();
			var customerInstantiationSettings = new CustomerInstantiationSettingsStub
			{
				DrinkRateMin = 1f,
				DrinkRateMax = 1f,
				StartingDrunkennessMax = 1f
			};
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
			var drinkSettings = new List<IDrinkSettings>()
			{
				new DrinkSettingsStub("drink1", 1, 1f)
			};
			var customerFactory = new CustomerFactory(messenger, random, time, customerInstantiationSettings,
					customerSharedSettings, drinkSettings);
			var customerInstantiatedMessageReceiverStub = new CustomerInstantiatedMessageReceiverStub(messenger);

			messenger.Publish(new CustomerInstantiateRequestedMessage(1, new Dictionary<IDrinkSettings, float>(),
					1f, 0f));

			Assert.IsNotNull(customerInstantiatedMessageReceiverStub.Message);
		}

		[Test]
		public void InstantiatesCustomerWithRandomizedMoneyBetweenMinAndMax_WhenCustomerInstantiateRequestedMessageIsPublished()
		{
			var customerStartingMoneyMin = 5;
			var customerStartingMoneyMax = 10;
			var time = new TimeStub();
			for(int randomReturnValue = customerStartingMoneyMin;
					randomReturnValue <= customerStartingMoneyMax;
					randomReturnValue++)
			{
				var messenger = new MessengerStub();
				var random = new RandomStub()
				{
					RandomDoubleValues = new List<double>() { 0.5, 0.5, 0.5 },
					RandomIntValues = new List<int>() { randomReturnValue }
				};
				var customerInstantiationSettings = new CustomerInstantiationSettingsStub
				{
					StartingMoneyMin = customerStartingMoneyMin,
					StartingMoneyMax = customerStartingMoneyMax,
					DrinkRateMin = 1f,
					DrinkRateMax = 1f,
					StartingDrunkennessMax = 1f
				};
				var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
				var drinkSettings = new List<IDrinkSettings>()
				{
					new DrinkSettingsStub("drink1", 1, 1f)
				};
				var customerFactory = new CustomerFactory(messenger, random, time, customerInstantiationSettings,
						customerSharedSettings, drinkSettings);
				var customerInstantiatedMessageReceiverStub = new CustomerInstantiatedMessageReceiverStub(messenger);

				messenger.Publish(new CustomerInstantiateRequestedMessage(1, new Dictionary<IDrinkSettings, float>(),
						1f, 0f));

				Assert.IsTrue(customerInstantiatedMessageReceiverStub.Message.Customer.Money >= customerStartingMoneyMin);
				Assert.IsTrue(customerInstantiatedMessageReceiverStub.Message.Customer.Money <= customerStartingMoneyMax);
			}
		}

		[Test]
		public void InstantiatesCustomerWithRandomizedDrinkSettingsWeights_WhenCustomerInstantiateRequestedMessageIsPublished()
		{
			var drink1Weight = 0.1f;
			var drink2Weight = 0.5f;
			var drink3Weight = 0.9f;
			var drinkSettings = new List<IDrinkSettings>()
			{
				new DrinkSettingsStub("drink1", 1, 1f),
				new DrinkSettingsStub("drink2", 1, 1f),
				new DrinkSettingsStub("drink3", 1, 1f)
			};
			var messenger = new MessengerStub();
			var random = new RandomStub()
			{
				RandomDoubleValues = new List<double>() { drink1Weight, drink2Weight, drink3Weight, 0.5f, 0.5f },
				RandomIntValues = new List<int>() { 1 }
			};
			var time = new TimeStub();
			var customerInstantiationSettings = new CustomerInstantiationSettingsStub
			{
				DrinkRateMin = 1f,
				DrinkRateMax = 1f,
				StartingDrunkennessMax = 1f
			};
			var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
			var customerFactory = new CustomerFactory(messenger, random, time, customerInstantiationSettings,
					customerSharedSettings, drinkSettings);
			var customerInstantiatedMessageReceiverStub = new CustomerInstantiatedMessageReceiverStub(messenger);

			messenger.Publish(new CustomerInstantiateRequestedMessage(1, new Dictionary<IDrinkSettings, float>(),
					1f, 0f));

			var drinkPreferenceWeights =
					customerInstantiatedMessageReceiverStub.Message.Customer.DrinkPreferenceWeights.Values.ToList();
			Assert.AreEqual(drink1Weight, drinkPreferenceWeights[0]);
			Assert.AreEqual(drink2Weight, drinkPreferenceWeights[1]);
			Assert.AreEqual(drink3Weight, drinkPreferenceWeights[2]);
		}

		[Test]
		public void InstantiatesCustomerWithRandomizedDrinkRateBetweenMinAndMax_WhenCustomerInstantiateRequestedMessageIsPublished()
		{
			var customerDrinkRateMin = 5f;
			var customerDrinkRateMax = 10f;
			var time = new TimeStub();
			for(float randomReturnValue = 0f;
					randomReturnValue <= 1f;
					randomReturnValue += 0.1f)
			{
				var messenger = new MessengerStub();
				var random = new RandomStub()
				{
					RandomDoubleValues = new List<double>() { 0.5, randomReturnValue, 0.5 },
					RandomIntValues = new List<int>() { 1 }
				};
				var customerInstantiationSettings = new CustomerInstantiationSettingsStub
				{
					DrinkRateMin = customerDrinkRateMin,
					DrinkRateMax = customerDrinkRateMax,
					StartingDrunkennessMax = 1f
				};
				var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
				var drinkSettings = new List<IDrinkSettings>()
				{
					new DrinkSettingsStub("drink1", 1, 1f)
				};
				var customerFactory = new CustomerFactory(messenger, random, time, customerInstantiationSettings,
						customerSharedSettings, drinkSettings);
				var customerInstantiatedMessageReceiverStub = new CustomerInstantiatedMessageReceiverStub(messenger);

				messenger.Publish(new CustomerInstantiateRequestedMessage(1, new Dictionary<IDrinkSettings, float>(),
						1f, 0f));
				
				Assert.IsTrue(customerInstantiatedMessageReceiverStub.Message.Customer.DrinkRate
						>= customerDrinkRateMin);
				Assert.IsTrue(customerInstantiatedMessageReceiverStub.Message.Customer.DrinkRate
						<= customerDrinkRateMax);
			}
		}

		[Test]
		public void InstantiatesCustomerWithRandomizedDrunkennessBetweenZeroAndMax_WhenCustomerInstantiateRequestedMessageIsPublished()
		{
			var customerStartingDrunkennessMax = 0.5f;
			var time = new TimeStub();
			for(float randomReturnValue = 0f;
					randomReturnValue <= 1f;
					randomReturnValue += 0.1f)
			{
				var messenger = new MessengerStub();
				var random = new RandomStub()
				{
					RandomDoubleValues = new List<double>() { 0.5, 0.5, randomReturnValue },
					RandomIntValues = new List<int>() { 1 }
				};
				var customerInstantiationSettings = new CustomerInstantiationSettingsStub
				{
					DrinkRateMin = 1f,
					DrinkRateMax = 1f,
					StartingDrunkennessMax = customerStartingDrunkennessMax
				};
				var customerSharedSettings = new CustomerSharedSettingsStub(1f, 1f, 1f);
				var drinkSettings = new List<IDrinkSettings>()
				{
					new DrinkSettingsStub("drink1", 1, 1f)
				};
				var customerFactory = new CustomerFactory(messenger, random, time, customerInstantiationSettings,
						customerSharedSettings, drinkSettings);
				var customerInstantiatedMessageReceiverStub = new CustomerInstantiatedMessageReceiverStub(messenger);

				messenger.Publish(new CustomerInstantiateRequestedMessage(1, new Dictionary<IDrinkSettings, float>(),
						1f, 0f));

				Assert.IsTrue(customerInstantiatedMessageReceiverStub.Message.Customer.Drunkenness >= 0f);
				Assert.IsTrue(customerInstantiatedMessageReceiverStub.Message.Customer.Drunkenness
						<= customerStartingDrunkennessMax);
			}
		}
	}
}
