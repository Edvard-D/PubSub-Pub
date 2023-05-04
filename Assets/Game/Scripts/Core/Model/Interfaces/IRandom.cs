namespace PubSubPub.Game.Core.Model
{
	public interface IRandom
	{
		public int Next();
		public int Next(int minValue, int maxValue);
		public double NextDouble();
	}
}
