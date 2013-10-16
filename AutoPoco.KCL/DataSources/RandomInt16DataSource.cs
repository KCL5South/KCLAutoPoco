namespace AutoPoco.KCL.DataSources
{
	public class RandomInt16DataSource : BaseRandomDataSource<System.Int16>
	{
		public RandomInt16DataSource() : base() { }
		internal RandomInt16DataSource(IRandomExtensions rand) : base(rand) { }

		public override System.Int16 Next(AutoPoco.Engine.IGenerationContext session)
		{
			return Random.GetInt16();
		}
	}
}