namespace PubSubPub.Game.Core.Model
{
	public class TimeWrapper : ITime
	{
		public float DeltaTime { get { return UnityEngine.Time.deltaTime; } }
		public float FixedDeltaTime { get { return UnityEngine.Time.fixedDeltaTime; } }
		public float Time { get { return UnityEngine.Time.time; } }
		public float TimeScale { get { return UnityEngine.Time.timeScale; } set { UnityEngine.Time.timeScale = value; } }
		public float UnscaledDeltaTime { get { return UnityEngine.Time.unscaledDeltaTime; } }
		public float UnscaledTime { get { return UnityEngine.Time.unscaledTime; } }
	}
}
