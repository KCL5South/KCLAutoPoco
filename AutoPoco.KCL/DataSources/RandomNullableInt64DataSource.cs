namespace AutoPoco.KCL.DataSources
{
	public class RandomNullableInt64DataSource : BaseRandomNullableDataSource<System.Int64>
	{
		public RandomNullableInt64DataSource() : base() { }
		public RandomNullableInt64DataSource(IRandomExtensions rand) : base(rand) { }

		protected override System.Int64 NextValue(AutoPoco.Engine.IGenerationContext session)
		{
			return Random.GetInt64();
		}
	}
}