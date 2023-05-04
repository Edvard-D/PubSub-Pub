using PubSubPub.Game.Core.Model;

namespace PubSubPub.Tests.Stubs
{
	public class TimeStub : ITime
	{
		public float DeltaTime { get; set; }
		public float FixedDeltaTime { get; set; }
		public float Time { get; set; }
		public float TimeScale { get; set; }
		public float UnscaledDeltaTime { get; set; }
		public float UnscaledTime { get; set; }


		public void Step(float deltaTime)
		{
			DeltaTime = deltaTime;
			FixedDeltaTime = deltaTime;
			Time += deltaTime;
			UnscaledDeltaTime = deltaTime;
			UnscaledTime += deltaTime;
		}
	}
}
