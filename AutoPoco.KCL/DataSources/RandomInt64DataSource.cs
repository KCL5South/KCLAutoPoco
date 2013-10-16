namespace AutoPoco.KCL.DataSources
{
	public class RandomInt64DataSource : BaseRandomDataSource<System.Int64>
	{
		public RandomInt64DataSource() : base() { }
		internal RandomInt64DataSource(IRandomExtensions rand) : base(rand) { }

		public override System.Int64 Next(AutoPoco.Engine.IGenerationContext session)
		{
			return Random.GetInt64();
		}
	}
}