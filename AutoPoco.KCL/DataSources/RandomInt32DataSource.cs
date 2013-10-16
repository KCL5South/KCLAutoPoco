namespace AutoPoco.KCL.DataSources
{
	public class RandomInt32DataSource : BaseRandomDataSource<System.Int32>
	{
		public RandomInt32DataSource() : base() { }
		internal RandomInt32DataSource(IRandomExtensions rand) : base(rand) { }

		public override System.Int32 Next(AutoPoco.Engine.IGenerationContext session)
		{
			return Random.GetInt32();
		}
	}
}