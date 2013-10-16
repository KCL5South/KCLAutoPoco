namespace AutoPoco.KCL.DataSources
{
	public class RandomBinaryDataSource : BaseRandomDataSource<System.Byte[]>
	{
		public int MinLength { get; private set; }
		public int MaxLength { get; private set; }

		public RandomBinaryDataSource() : this(1, 100) { }
		public RandomBinaryDataSource(int minLength, int maxLength) : base() 
		{ 
			if(maxLength < minLength)
				throw new System.ArgumentException("maxLength must be greater or equal to minLength");
			MinLength = minLength; 
			MaxLength = maxLength;
		}
		internal RandomBinaryDataSource(IRandomExtensions rand, int minLength, int maxLength) : base(rand) 
		{ 
			if(maxLength < minLength)
				throw new System.ArgumentException("maxLength must be greater or equal to minLength");
			MinLength = minLength; 
			MaxLength = maxLength;
		}

		public override System.Byte[] Next(AutoPoco.Engine.IGenerationContext session)
		{
			return Random.GetBinary(MinLength, MaxLength);
		}
	}
}