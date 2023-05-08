using PubSubPub.Game.Core.Model;

namespace PubSubPub.Game.Core.Messages
{
	public class CustomerDrinkSoldMessage
	{
		public CustomerDrinkSoldMessage(
				Customer customer,
				Drink drink)
		{
			Customer = customer;
			Drink = drink;
		}


		public Customer Customer { get; private set; }
		public Drink Drink { get; private set; }
	}
}
