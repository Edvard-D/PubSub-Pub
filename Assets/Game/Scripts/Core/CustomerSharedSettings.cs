using UnityEngine;

namespace PubSubPub.Game.Core.Model
{
	[CreateAssetMenu(fileName = "CustomerSharedSettings", menuName = "PubSubPub/CustomerSharedSettings")]
	public class CustomerSharedSettings : ScriptableObject
	{
		[SerializeField]
		private float _drunkennessIncreaseMultiplier;
		[SerializeField]
		private float _drunkennessPassedOutThreshold;
		[SerializeField]
		private float _delayBetweenDrinks;


		public float DrunkennessIncreaseMultiplier { get { return _drunkennessIncreaseMultiplier; } }
		public float DrunkennessPassedOutThreshold { get { return _drunkennessPassedOutThreshold; } }
		public float DelayBetweenDrinks { get { return _delayBetweenDrinks; } }
	}
}
