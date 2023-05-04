using PubSubPub.Game.Core.Model;

namespace PubSubPub.Tests.Stubs
{
	public class CustomerSharedSettingsStub : ICustomerSharedSettings
	{
		public CustomerSharedSettingsStub(
				float drunkennessIncreaseMultiplier,
				float drunkennessPassedOutThreshold,
				float delayBetweenDrinks)
		{
			DelayBetweenDrinks = delayBetweenDrinks;
			DrunkennessIncreaseMultiplier = drunkennessIncreaseMultiplier;
			DrunkennessPassedOutThreshold = drunkennessPassedOutThreshold;
		}


		public float DelayBetweenDrinks { get; }
		public float DrunkennessIncreaseMultiplier { get; }
		public float DrunkennessPassedOutThreshold { get; }
	}
}
