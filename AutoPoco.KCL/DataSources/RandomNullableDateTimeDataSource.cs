namespace AutoPoco.KCL.DataSources
{
	public class RandomNullableDateTimeDataSource : BaseRandomNullableDataSource<System.DateTime>
	{
		public static readonly System.DateTime MinValue = new System.DateTime(1900, 1, 1);

		public RandomNullableDateTimeDataSource() : base() { }
		public RandomNullableDateTimeDataSource(IRandomExtensions rand) : base(rand) { }

		protected override System.DateTime NextValue(AutoPoco.Engine.IGenerationContext session)
		{
			return Random.GetDateTime(MinValue, System.DateTime.MaxValue);
		}
	}
}