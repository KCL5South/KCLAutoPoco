namespace AutoPoco.KCL.DataSources
{
	public class RandomDateTimeDataSource : BaseRandomDataSource<System.DateTime>
	{
		public static readonly System.DateTime MinValue = new System.DateTime(1900, 1, 1);

		public RandomDateTimeDataSource() : base() { }
		internal RandomDateTimeDataSource(IRandomExtensions rand) : base(rand) { }

		public override System.DateTime Next(AutoPoco.Engine.IGenerationContext session)
		{
			return Random.GetDateTime(MinValue, System.DateTime.MaxValue);
		}
	}
}