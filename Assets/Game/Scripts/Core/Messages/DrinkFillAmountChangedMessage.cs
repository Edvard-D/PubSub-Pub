using PubSubPub.Game.Core.Model;

namespace PubSubPub.Game.Core.Messages
{
	public class DrinkFillAmountChangedMessage
	{
		public DrinkFillAmountChangedMessage(
				Drink drink,
				float fillAmount)
		{
			Drink = drink;
			FillAmount = fillAmount;
		}


		public Drink Drink { get; private set; }
		public float FillAmount { get; private set; }
	}
}