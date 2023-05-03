namespace PubSubPub.Game.Core.Model
{
	public interface ITime
	{
		float DeltaTime { get; }
		float FixedDeltaTime { get; }
		float Time { get; }
		float TimeScale { get; set; }
		float UnscaledDeltaTime { get; }
		float UnscaledTime { get; }
	}
}
