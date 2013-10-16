namespace AutoPoco.KCL.DataSources
{
	public class RandomNullableInt32DataSource : BaseRandomNullableDataSource<System.Int32>
	{
		public RandomNullableInt32DataSource() : base() { }
		public RandomNullableInt32DataSource(IRandomExtensions rand) : base(rand) { }

		protected override System.Int32 NextValue(AutoPoco.Engine.IGenerationContext session)
		{
			return Random.GetInt32();
		}
	}
}