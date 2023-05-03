using UnityEngine;

namespace PubSubPub.Game.Core.Model
{
	public interface IDrinkSettings
	{
		float AlcoholPercent { get; }
		Texture2D Icon { get; }
		string Name { get; }
		int Price { get; }
	}
}
