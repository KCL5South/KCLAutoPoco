namespace AutoPoco.KCL.DataSources
{
	public class RandomNullableInt16DataSource : BaseRandomNullableDataSource<System.Int16>
	{
		public RandomNullableInt16DataSource() : base() { }
		public RandomNullableInt16DataSource(IRandomExtensions rand) : base(rand) { }

		protected override System.Int16 NextValue(AutoPoco.Engine.IGenerationContext session)
		{
			return Random.GetInt16();
		}
	}
}