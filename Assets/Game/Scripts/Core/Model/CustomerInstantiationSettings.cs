using UnityEngine;

namespace PubSubPub.Game.Core.Model
{
	[CreateAssetMenu(fileName = "CustomerInstantiationSettings", menuName = "PubSubPub/CustomerInstantiationSettings")]
	public class CustomerInstantiationSettings : ScriptableObject, ICustomerInstantiationSettings
	{
		[SerializeField]
		private int _startingMoneyMin;
		[SerializeField]
		private int _startingMoneyMax;
		[SerializeField]
		private float _startingDrunkennessMax;
		[SerializeField]
		private float _drinkRateMin;
		[SerializeField]
		private float _drinkRateMax;


		public float DrinkRateMax { get { return _drinkRateMax; } }
		public float DrinkRateMin { get { return _drinkRateMin; } }
		public float StartingDrunkennessMax { get { return _startingDrunkennessMax; } }
		public int StartingMoneyMax { get { return _startingMoneyMax; } }
		public int StartingMoneyMin { get { return _startingMoneyMin; } }
	}
}
