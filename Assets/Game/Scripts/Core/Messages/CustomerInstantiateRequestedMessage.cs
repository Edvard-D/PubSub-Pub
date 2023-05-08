using System.Collections.Generic;
using PubSubPub.Game.Core.Model;

namespace PubSubPub.Game.Core.Messages
{
	public class CustomerInstantiateRequestedMessage
	{
		public CustomerInstantiateRequestedMessage(
				int money,
				Dictionary<IDrinkSettings, float> drinkPreferenceWeights,
				float drinkSpeed,
				float drunkenness)
		{
			Money = money;
			DrinkPreferenceWeights = drinkPreferenceWeights;
			DrinkSpeed = drinkSpeed;
			Drunkenness = drunkenness;
		}


		public int Money { get; private set; }
		public Dictionary<IDrinkSettings, float> DrinkPreferenceWeights { get; private set; }
		public float DrinkSpeed { get; private set; }
		public float Drunkenness { get; private set; }
	}
}
