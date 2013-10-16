namespace AutoPoco.KCL.DataSources
{
	public class RandomNullableDecimalDataSource : BaseRandomNullableDataSource<System.Decimal>
	{
		public RandomNullableDecimalDataSource() : base() { }
		public RandomNullableDecimalDataSource(IRandomExtensions rand) : base(rand) { }

		protected override System.Decimal NextValue(AutoPoco.Engine.IGenerationContext session)
		{
			return Random.GetDecimal();
		}
	}
}