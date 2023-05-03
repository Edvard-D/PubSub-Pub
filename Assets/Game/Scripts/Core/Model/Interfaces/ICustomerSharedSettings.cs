namespace PubSubPub.Game.Core.Model
{
	public interface ICustomerSharedSettings
	{
		public float DrunkennessIncreaseMultiplier { get; }
		public float DrunkennessPassedOutThreshold { get; }
		public float DelayBetweenDrinks { get; }
	}
}
