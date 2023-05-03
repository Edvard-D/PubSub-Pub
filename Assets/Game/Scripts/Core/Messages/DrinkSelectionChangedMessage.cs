using PubSubPub.Game.Core.Model;

namespace PubSubPub.Game.Core.Messages
{
	public class DrinkSelectionChangedMessage
	{
		public DrinkSelectionChangedMessage(IDrinkSettings drinkSettings)
		{
			DrinkSettings = drinkSettings;
		}


		public IDrinkSettings DrinkSettings { get; private set; }
	}
}
