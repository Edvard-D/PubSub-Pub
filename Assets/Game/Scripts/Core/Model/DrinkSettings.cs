using UnityEngine;

namespace PubSubPub.Game.Core.Model
{
	[CreateAssetMenu(fileName = "DrinkSettings", menuName = "PubSubPub/DrinkSettings")]
	public class DrinkSettings : ScriptableObject
	{
		[SerializeField]
		private string _name;
		[SerializeField]
		private Texture2D _icon;
		[SerializeField]
		private int _price;
		[SerializeField]
		private float _alcoholPercent;


		public float AlcoholPercent { get { return _alcoholPercent; } }
		public Texture2D Icon { get { return _icon; } }
		public string Name { get { return _name; } }
		public int Price { get { return _price; } }
	}
}
