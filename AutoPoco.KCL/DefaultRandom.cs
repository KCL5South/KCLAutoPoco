namespace AutoPoco.KCL
{
	internal class DefaultRandom : IRandom, IRandomExtensions
	{
		public System.Random _rand = null;

		public DefaultRandom(int seed) { _rand = new System.Random(seed); }

		#region IRandom Members

		public int Next() { return _rand.Next(); }
		public int Next(int maxValue) { return _rand.Next(maxValue); }
		public int Next(int minValue, int maxValue) { return _rand.Next(minValue, maxValue); }
		public void NextBytes(byte[] buffer) { _rand.NextBytes(buffer); }
		public double NextDouble() { return _rand.NextDouble(); }

		#endregion

		#region IRandomExtensions Members

		public System.Boolean GetBoolean()
		{
			return RandomExtensions.GetBoolean(this);
		}
		public System.Byte GetByte(System.Byte min = System.Byte.MinValue, System.Byte max = System.Byte.MaxValue)
		{
			return RandomExtensions.GetByte(this, min, max);
		}
		public System.Int16 GetInt16(System.Int16 min = System.Int16.MinValue, System.Int16 max = System.Int16.MaxValue)
		{
			return RandomExtensions.GetInt16(this, min, max);
		}
		public System.Int32 GetInt32(System.Int32 min = System.Int32.MinValue, System.Int32 max = System.Int32.MaxValue)
		{
			return RandomExtensions.GetInt32(this, min, max);
		}
		public System.Int64 GetInt64(System.Int64 min = System.Int64.MinValue, System.Int64 max = System.Int64.MaxValue)
		{
			return RandomExtensions.GetInt64(this, min, max);
		}
		public System.Double GetDouble(System.Double min = System.Double.MinValue, System.Double max = System.Double.MaxValue)
		{
			return RandomExtensions.GetDouble(this, min, max);
		}
		public System.Single GetSingle(System.Single min = System.Single.MinValue, System.Single max = System.Single.MaxValue)
		{
			return RandomExtensions.GetSingle(this, min, max);
		}
		public System.Decimal GetDecimal(System.Decimal min = System.Decimal.MinValue, System.Decimal max = System.Decimal.MaxValue)
		{
			return RandomExtensions.GetDecimal(this, min, max);
		}
		public System.DateTime GetDateTime(System.DateTime min, System.DateTime max)
		{
			return RandomExtensions.GetDateTime(this, min, max);
		}
		public System.Guid GetGuid()
		{
			return RandomExtensions.GetGuid(this);
		}
		public System.Byte[] GetBinary(int minLength, int maxLength)
		{
			return RandomExtensions.GetBinary(this, minLength, maxLength);
		}

		#endregion
	}
}