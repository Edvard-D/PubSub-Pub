using NUnit.Framework;
using PubSubPub.Game.Core.Model;
using PubSubPub.Tests.Stubs;
using UnityEngine;
using UnityEngine.TestTools;

namespace PubSubPub.Tests.Core.Model
{
    public class DrinkTests
    {
		[Test]
		public void Constructor_ThrowsArgumentNullException_WhenSettingsIsNull()
		{
			Assert.Throws<System.ArgumentNullException>(() => new Drink(null));
		}

		[Test]
		public void Constructor_SetsFillAmountTo1()
		{
			var messenger = new MessengerStub();
			var drink = new Drink(new DrinkSettingsStub());
			drink.Initialize(messenger);

			Assert.AreEqual(1f, drink.FillAmount);
		}

		[Test]
		public void FillAmount_SetsValueToZero_WhenValueIsBelowZero()
		{
			var messenger = new MessengerStub();
			var drink = new Drink(new DrinkSettingsStub());
			drink.Initialize(messenger);

			drink.DrinkDrink(2f);

			Assert.AreEqual(0f, drink.FillAmount);
		}

		[Test]
		public void FillAmount_PublishesDrinkFillAmountChangedMessage_WhenValueChanges()
		{
			var messenger = new MessengerStub();
			var drink = new Drink(new DrinkSettingsStub());
			drink.Initialize(messenger);
			var subscriber = new DrinkFillAmountChangedMessageSubscriberStub(messenger);

			drink.DrinkDrink(1f);

			Assert.AreEqual(subscriber.Message.Drink, drink);
			Assert.AreEqual(subscriber.Message.FillAmount, 0f);
		}

		[Test]
		public void DrinkDrink_LogsError_WhenAmountIsBelowZero()
		{
			var messenger = new MessengerStub();
			var drink = new Drink(new DrinkSettingsStub());
			drink.Initialize(messenger);

			drink.DrinkDrink(-1f);

			LogAssert.Expect(LogType.Error, "Argument amount cannot be less than or equal to zero.");
		}

		[Test]
		public void DrinkDrink_LogsError_WhenAmountIsZero()
		{
			var messenger = new MessengerStub();
			var drink = new Drink(new DrinkSettingsStub());
			drink.Initialize(messenger);

			drink.DrinkDrink(0f);

			LogAssert.Expect(LogType.Error, "Argument amount cannot be less than or equal to zero.");
		}
		
		[Test]
		public void DrinkDrink_ChangesFillAmount_WhenAmountIsAboveZero()
		{
			var messenger = new MessengerStub();
			var drink = new Drink(new DrinkSettingsStub());
			drink.Initialize(messenger);

			drink.DrinkDrink(0.5f);

			Assert.AreEqual(0.5f, drink.FillAmount);
		}
    }
}
