namespace AutoPoco.KCL.DataSources
{
	public class RandomNullableByteDataSource : BaseRandomNullableDataSource<System.Byte>
	{
		public RandomNullableByteDataSource() : base() { }
		public RandomNullableByteDataSource(IRandomExtensions rand) : base(rand) { }

		protected override System.Byte NextValue(AutoPoco.Engine.IGenerationContext session)
		{
			return Random.GetByte();
		}
	}
}