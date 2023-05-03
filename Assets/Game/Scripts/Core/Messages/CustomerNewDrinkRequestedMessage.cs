using PubSubPub.Game.Core.Model;

namespace PubSubPub.Game.Core.Messages
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
