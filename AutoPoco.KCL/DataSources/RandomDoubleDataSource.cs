namespace AutoPoco.KCL.DataSources
{
	public class RandomDoubleDataSource : BaseRandomDataSource<System.Double>
	{
		public RandomDoubleDataSource() : base() { }
		internal RandomDoubleDataSource(IRandomExtensions rand) : base(rand) { }

		public override System.Double Next(AutoPoco.Engine.IGenerationContext session)
		{
			return Random.GetDouble();
		}
	}
}