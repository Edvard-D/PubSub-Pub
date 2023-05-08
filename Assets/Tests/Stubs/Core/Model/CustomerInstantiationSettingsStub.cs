using PubSubPub.Game.Core.Model;

namespace PubSubPub.Tests.Stubs.Core.Model
{
	public class CustomerInstantiationSettingsStub : ICustomerInstantiationSettings
	{
		public int StartingMoneyMin { get; set; }
		public int StartingMoneyMax { get; set; }
		public float StartingDrunkennessMax { get; set; }
		public float DrinkRateMin { get; set; }
		public float DrinkRateMax { get; set; }
	}
}
