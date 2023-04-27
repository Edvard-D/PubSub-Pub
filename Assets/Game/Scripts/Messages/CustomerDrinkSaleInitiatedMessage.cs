using PubSubPub.Core;

namespace PubSubPub.Messages
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
