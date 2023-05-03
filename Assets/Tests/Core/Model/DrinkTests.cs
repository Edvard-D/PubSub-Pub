using NUnit.Framework;
using PubSubPub.Game.Core.Messages;
using PubSubPub.Game.Core.Model;
using SuperMaxim.Messaging;
using UnityEngine;
using UnityEngine.TestTools;

namespace PubSubPub.Tests.Core.Model
{
    public class DrinkTests
    {
		[Test]
		public void DrinkConstructor_SetsFillAmountTo1()
		{
			var drink = new Drink(new DrinkSettings());

			Assert.AreEqual(1f, drink.FillAmount);
		}

		[Test]
		public void FillAmount_SetsValueToZero_WhenValueIsBelowZero()
		{
			var drink = new Drink(new DrinkSettings());

			drink.DrinkDrink(-1f);

			Assert.AreEqual(0f, drink.FillAmount);
		}

		[Test]
		public void FillAmount_SetsValueToOne_WhenValueIsAboveOne()
		{
			var drink = new Drink(new DrinkSettings());

			drink.DrinkDrink(2f);

			Assert.AreEqual(1f, drink.FillAmount);
		}

		[Test]
		public void FillAmount_PublishesDrinkFillAmountChangedMessage_WhenValueChanges()
		{
			var drink = new Drink(new DrinkSettings());
			var subscriber = new DrinkFillAmountChangedMessageSubscriber();

			drink.DrinkDrink(1f);

			Assert.AreEqual(subscriber.Message.Drink, drink);
			Assert.AreEqual(subscriber.Message.FillAmount, 0f);
		}

        [Test]
        public void DrinkDrink_Returns_WhenAmountIsBelowZero()
        {
			var drink = new Drink(new DrinkSettings());

			drink.DrinkDrink(-1f);

			Assert.AreEqual(1f, drink.FillAmount);
        }

		[Test]
		public void DrinkDrink_Returns_WhenAmountIsZero()
		{
			var drink = new Drink(new DrinkSettings());

			drink.DrinkDrink(0f);

			Assert.AreEqual(1f, drink.FillAmount);
		}

		[Test]
		public void DrinkDrink_LogsError_WhenAmountIsBelowZero()
		{
			var drink = new Drink(new DrinkSettings());

			drink.DrinkDrink(-1f);

			LogAssert.Expect(LogType.Error, "Argument amount cannot be less than or equal to zero.");
		}

		[Test]
		public void DrinkDrink_LogsError_WhenAmountIsZero()
		{
			var drink = new Drink(new DrinkSettings());

			drink.DrinkDrink(0f);

			LogAssert.Expect(LogType.Error, "Argument amount cannot be less than or equal to zero.");
		}
		
		[Test]
		public void DrinkDrink_ChangesFillAmount_WhenAmountIsAboveZero()
		{
			var drink = new Drink(new DrinkSettings());

			drink.DrinkDrink(0.5f);

			Assert.AreEqual(0.5f, drink.FillAmount);
		}


		public class DrinkFillAmountChangedMessageSubscriber
		{
			public DrinkFillAmountChangedMessageSubscriber()
			{
				Messenger.Default.Subscribe<DrinkFillAmountChangedMessage>(OnDrinkFillAmountChangedMessageReceived);
			}


			public DrinkFillAmountChangedMessage Message { get; private set; }


			private void OnDrinkFillAmountChangedMessageReceived(DrinkFillAmountChangedMessage message)
			{
				Message = message;
			}
		}
    }
}
