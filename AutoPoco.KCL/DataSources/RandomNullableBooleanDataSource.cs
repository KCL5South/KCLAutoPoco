namespace AutoPoco.KCL.DataSources
{
	public class RandomNullableBooleanDataSource : BaseRandomNullableDataSource<System.Boolean>
	{
		public RandomNullableBooleanDataSource() : base() { }
		public RandomNullableBooleanDataSource(IRandomExtensions rand) : base(rand) { }

		protected override System.Boolean NextValue(AutoPoco.Engine.IGenerationContext session)
		{
			return Random.GetBoolean();
		}
	}
}