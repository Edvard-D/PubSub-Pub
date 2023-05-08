namespace PubSubPub.Game.Core.Model
{
	public interface IPubSettings
	{
		public float CustomerStartingDelayBetweenSpawns { get; }
		public float CustomerMinDelayBetweenSpawns { get; }
		public float CustomerDelayBetweenSpawnsDecreaseRate { get; }
	}
}
