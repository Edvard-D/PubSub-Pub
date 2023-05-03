using PubSubPub.Game.Core.Model;

namespace PubSubPub.Game.Core.Messages
{
	public class CustomerDrinkSaleInitiatedMessage
	{
		public CustomerDrinkSaleInitiatedMessage(
				Customer customer,
				IDrinkSettings drink)
		{
			Customer = customer;
			DrinkSettings = drink;
		}


		public Customer Customer { get; private set; }
		public IDrinkSettings DrinkSettings { get; private set; }
	}
}
