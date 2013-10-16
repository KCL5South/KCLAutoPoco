namespace AutoPoco.KCL.DataSources
{
	public class RandomBooleanDataSource : BaseRandomDataSource<System.Boolean>
	{
		public RandomBooleanDataSource() : base() { }
		internal RandomBooleanDataSource(IRandomExtensions rand) : base(rand) { }

		public override System.Boolean Next(AutoPoco.Engine.IGenerationContext session)
		{
			return Random.GetBoolean();
		}
	}
}