using PubSubPub.Game.Core.Model;

namespace PubSubPub.Tests.Stubs.Core.Model
{
	public class PubSettingsStub : IPubSettings
	{
		public float CustomerStartingDelayBetweenSpawns { get; set; }
		public float CustomerMinDelayBetweenSpawns { get; set; }
		public float CustomerDelayBetweenSpawnsDecreaseRate { get; set; }
	}
}
