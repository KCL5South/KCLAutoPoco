namespace AutoPoco.KCL.DataSources
{
	public class RandomNullableStringDataSource : AutoPoco.DataSources.RandomStringSource
	{
		public IRandomExtensions Random { get; private set; }

		public RandomNullableStringDataSource() : this(1, 100) { }
		public RandomNullableStringDataSource(int min, int max) : this(new DefaultRandom(13), min, max) { }
		internal RandomNullableStringDataSource(IRandomExtensions rand, int min, int max) : base(min, max)
		{
			Random = rand;
		}

		public override string Next(AutoPoco.Engine.IGenerationContext session)
		{
			if(Random.GetBoolean())
				return null;
			else
				return base.Next(session);
		}
	}
}