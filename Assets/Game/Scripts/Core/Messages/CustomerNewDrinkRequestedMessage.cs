using PubSubPub.Game.Core.Model;

namespace PubSubPub.Game.Core.Messages
{
	public class CustomerNewDrinkRequestedMessage
	{
		public CustomerNewDrinkRequestedMessage(
				Customer customer,
				IDrinkSettings drinkSettings)
		{
			Customer = customer;
			DrinkSettings = drinkSettings;
		}


		public Customer Customer { get; private set; }
		public IDrinkSettings DrinkSettings { get; private set; }
	}
}
