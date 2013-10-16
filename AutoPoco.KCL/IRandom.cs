namespace AutoPoco.KCL
{
	public interface IRandom
	{
		int Next();
		int Next(int maxValue);
		int Next(int minValue, int MaxValue);
		void NextBytes(byte[] buffer);
		double NextDouble();
	}
}