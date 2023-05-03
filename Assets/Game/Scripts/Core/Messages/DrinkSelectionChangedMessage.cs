using PubSubPub.Game.Core.Model;

namespace PubSubPub.Game.Core.Messages
{
	public class DrinkSelectionChangedMessage
	{
		public DrinkSelectionChangedMessage(DrinkSettings drinkSettings)
		{
			DrinkSettings = drinkSettings;
		}


		public DrinkSettings DrinkSettings { get; private set; }
	}
}
