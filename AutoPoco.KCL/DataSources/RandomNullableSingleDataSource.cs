namespace AutoPoco.KCL.DataSources
{
	public class RandomNullableSingleDataSource : BaseRandomNullableDataSource<System.Single>
	{
		public RandomNullableSingleDataSource() : base() { }
		public RandomNullableSingleDataSource(IRandomExtensions rand) : base(rand) { }

		protected override System.Single NextValue(AutoPoco.Engine.IGenerationContext session)
		{
			return Random.GetSingle();
		}
	}
}