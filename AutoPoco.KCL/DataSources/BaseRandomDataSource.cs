namespace AutoPoco.KCL
{
	public abstract class BaseRandomDataSource<T> : AutoPoco.Engine.DatasourceBase<T>
	{
		public static readonly int Seed = 13;

		public IRandomExtensions Random { get; private set; }

		public BaseRandomDataSource() : this(new DefaultRandom(Seed)) { }
		internal BaseRandomDataSource(IRandomExtensions random) { Random = random; }
	}
}