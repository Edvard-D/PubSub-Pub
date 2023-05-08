namespace PubSubPub.Game.Core.Model
{
	public interface ICustomerInstantiationSettings
	{
		public int StartingMoneyMin { get; }
		public int StartingMoneyMax { get; }
		public float StartingDrunkennessMax { get; }
		public float DrinkRateMin { get; }
		public float DrinkRateMax { get; }
	}
}
