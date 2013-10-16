namespace AutoPoco.KCL.DataSources
{
	public class RandomNullableDoubleDataSource : BaseRandomNullableDataSource<System.Double>
	{
		public RandomNullableDoubleDataSource() : base() { }
		public RandomNullableDoubleDataSource(IRandomExtensions rand) : base(rand) { }

		protected override System.Double NextValue(AutoPoco.Engine.IGenerationContext session)
		{
			return Random.GetDouble();
		}
	}
}