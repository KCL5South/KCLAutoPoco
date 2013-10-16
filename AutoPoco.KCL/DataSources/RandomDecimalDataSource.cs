namespace AutoPoco.KCL.DataSources
{
	public class RandomDecimalDataSource : BaseRandomDataSource<System.Decimal>
	{
		public RandomDecimalDataSource() : base() { }
		internal RandomDecimalDataSource(IRandomExtensions rand) : base(rand) { }

		public override System.Decimal Next(AutoPoco.Engine.IGenerationContext session)
		{
			return Random.GetDecimal();
		}
	}
}