using System.Collections.Generic;

namespace PubSubPub.Game.Core.Model
{
	public class RandomStub : IRandom
	{
		public List<double> RandomDoubleValues { get; set; }
		public List<int> RandomIntValues { get; set; }


		public int Next()
		{
			var nextValue = RandomIntValues[0];
			RandomIntValues.RemoveAt(0);

			return nextValue;
		}

		public int Next(int minValue, int maxValue)
		{
			var nextValue = RandomIntValues[0];
			RandomIntValues.RemoveAt(0);

			return nextValue;
		}

		public double NextDouble()
		{
			var nextValue = RandomDoubleValues[0];
			RandomDoubleValues.RemoveAt(0);

			return nextValue;
		}
	}
}
