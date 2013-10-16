namespace AutoPoco.KCL.DataSources
{
	public abstract class BaseRandomNullableDataSource<T> : BaseRandomDataSource<System.Nullable<T>>
		where T : struct
	{
		public BaseRandomNullableDataSource() : base() { }
		internal BaseRandomNullableDataSource(IRandomExtensions rand) : base(rand) { }

		protected abstract T NextValue(AutoPoco.Engine.IGenerationContext session);

		public override System.Nullable<T> Next(AutoPoco.Engine.IGenerationContext session)
		{
			if(Random.GetBoolean())
				return null;
			else
				return NextValue(session);
		}
	}
}