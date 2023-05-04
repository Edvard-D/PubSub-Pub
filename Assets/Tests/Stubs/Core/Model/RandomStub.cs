using System.Collections.Generic;

namespace PubSubPub.Game.Core.Model
{
	public class RandomStub : IRandom
	{
		private List<double> _randomValues;


		public RandomStub(List<double> randomValues)
		{
			_randomValues = randomValues;
		}


		public int Next()
		{
			throw new System.NotImplementedException();
		}

		public int Next(int minValue, int maxValue)
		{
			throw new System.NotImplementedException();
		}

		public double NextDouble()
		{
			var nextValue = _randomValues[0];
			_randomValues.RemoveAt(0);

			return nextValue;
		}
	}
}
