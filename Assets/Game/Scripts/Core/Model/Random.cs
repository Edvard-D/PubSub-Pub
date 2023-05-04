namespace PubSubPub.Game.Core.Model
{
	public class Random : IRandom
	{
		private System.Random _random;


		public Random()
		{
			_random = new System.Random();
		}
		public Random(int seed)
		{
			_random = new System.Random(seed);
		}


		public int Next()
		{
			return _random.Next();
		}

		public int Next(int minValue, int maxValue)
		{
			return _random.Next(minValue, maxValue);
		}

		public double NextDouble()
		{
			return _random.NextDouble();
		}
	}	
}
