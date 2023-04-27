using PubSubPub.Core;

namespace PubSubPub.Messages
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
