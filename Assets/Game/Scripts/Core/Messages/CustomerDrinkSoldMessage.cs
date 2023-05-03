using PubSubPub.Game.Core.Model;

namespace PubSubPub.Game.Core.Messages
{
	public class CustomerDrinkSoldMessage
	{
		public CustomerDrinkSoldMessage(
				Customer customer,
				Drink _drink)
		{
			Customer = customer;
			Drink = _drink;
		}


		public Customer Customer { get; private set; }
		public Drink Drink { get; private set; }
	}
}
