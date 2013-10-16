namespace AutoPoco.KCL.DataSources
{
	public class RandomByteDataSource : BaseRandomDataSource<System.Byte>
	{
		public RandomByteDataSource() : base() { }
		internal RandomByteDataSource(IRandomExtensions rand) : base(rand) { }

		public override System.Byte Next(AutoPoco.Engine.IGenerationContext session)
		{
			return Random.GetByte();
		}
	}
}