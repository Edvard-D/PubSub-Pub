using PubSubPub.Game.Core.Model;

namespace PubSubPub.Game.Core.Messages
{
	public class CustomerDrinkSaleInitiatedMessage
	{
		public CustomerDrinkSaleInitiatedMessage(
				Customer customer,
				DrinkSettings drink)
		{
			Customer = customer;
			DrinkSettings = drink;
		}


		public Customer Customer { get; private set; }
		public DrinkSettings DrinkSettings { get; private set; }
	}
}
