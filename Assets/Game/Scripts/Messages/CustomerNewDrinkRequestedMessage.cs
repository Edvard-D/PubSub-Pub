using PubSubPub.Core;

namespace PubSubPub.Messages
{
	public class CustomerNewDrinkRequestedMessage
	{
		public CustomerNewDrinkRequestedMessage(
				Customer customer,
				DrinkSettings drinkSettings)
		{
			Customer = customer;
			DrinkSettings = drinkSettings;
		}


		public Customer Customer { get; private set; }
		public DrinkSettings DrinkSettings { get; private set; }
	}
}