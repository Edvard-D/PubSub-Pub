using UnityEngine;

namespace PubSubPub.Game.Core.Model
{
	public static class RandomHelpers
	{
		public static double RandomRange(
				IRandom random,
				float minValue,
				float maxValue,
				bool shouldRandomizeSign = false,
				bool shouldRound = false)
		{
			var randomValue = (random.NextDouble() * (minValue - maxValue)) + minValue;
			randomValue *= shouldRandomizeSign == true && random.NextDouble() < 0.5D ? -1 : 1;

			if(shouldRound == true)
			{
				randomValue = Mathf.Round((float)randomValue);
			}
			
			return randomValue;
		}
	}
}
