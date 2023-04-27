using PubSubPub.Core;

namespace PubSubPub.Messages
{
	public class DrinkFillAmountChangedMessage
	{
		public DrinkFillAmountChangedMessage(
				Customer customer,
				Drink drink,
				float fillAmount)
		{
			Customer = customer;
			Drink = drink;
			FillAmount = fillAmount;
		}


		public Customer Customer { get; private set; }
		public Drink Drink { get; private set; }
		public float FillAmount { get; private set; }
	}
}