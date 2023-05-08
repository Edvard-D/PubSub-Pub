using UnityEngine;

namespace PubSubPub.Game.Core.Model
{
	[CreateAssetMenu(fileName = "PubSettings", menuName = "PubSubPub/PubSettings")]
	public class PubSettings : ScriptableObject, IPubSettings
	{
		[SerializeField]
		private float _customerStartingDelayBetweenSpawns;
		[SerializeField]
		private float _customerMinDelayBetweenSpawns;
		[SerializeField]
		private float _customerDelayBetweenSpawnsDecreaseRate;


		public float CustomerDelayBetweenSpawnsDecreaseRate { get { return _customerDelayBetweenSpawnsDecreaseRate; } }
		public float CustomerMinDelayBetweenSpawns { get { return _customerMinDelayBetweenSpawns; } }
		public float CustomerStartingDelayBetweenSpawns { get { return _customerStartingDelayBetweenSpawns; } }
	}
}
