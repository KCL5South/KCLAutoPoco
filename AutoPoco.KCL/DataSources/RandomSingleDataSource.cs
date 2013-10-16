namespace AutoPoco.KCL.DataSources
{
	public class RandomSingleDataSource : BaseRandomDataSource<System.Single>
	{
		public RandomSingleDataSource() : base() { }
		internal RandomSingleDataSource(IRandomExtensions rand) : base(rand) { }

		public override System.Single Next(AutoPoco.Engine.IGenerationContext session)
		{
			return Random.GetSingle();
		}
	}
}