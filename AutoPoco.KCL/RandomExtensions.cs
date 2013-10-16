namespace AutoPoco.KCL
{
	public static class RandomExtensions
	{
		public static System.Boolean GetBoolean(IRandom rand)
		{
			return rand.Next() % 2 == 1;
		}

		public static System.Byte GetByte(	IRandom rand,
											System.Byte min = System.Byte.MinValue,
											System.Byte max = System.Byte.MaxValue)
		{
			return (System.Byte)rand.Next((int)min, (int)max);
		}

		public static System.Int16 GetInt16(IRandom rand,
											System.Int16 min = System.Int16.MinValue,
											System.Int16 max = System.Int16.MaxValue)
		{
			return (System.Int16)rand.Next((int)min, (int)max);
		}

		public static System.Int32 GetInt32(IRandom rand, 
											System.Int32 min = System.Int32.MinValue,
											System.Int32 max = System.Int32.MaxValue)
		{
			return rand.Next(min, max);
		}

		public static System.Int64 GetInt64(IRandom rand, 
											System.Int64 min = System.Int64.MinValue,
											System.Int64 max = System.Int64.MaxValue)
		{
			byte[] buffer = new byte[8];
			rand.NextBytes(buffer);

			System.Int64 result = System.BitConverter.ToInt64(buffer, 0);

			if(result < min)
				return min;
			else if(result >= max)
				return max - 1;
			else
				return result;
		}

		public static System.Double GetDouble(	IRandom rand, 
												System.Double min = System.Double.MinValue, 
												System.Double max = System.Double.MaxValue)
		{
			byte[] buffer = new byte[8];
			rand.NextBytes(buffer);

			System.Double result = System.BitConverter.ToDouble(buffer, 0);

			if(result < min)
				return min;
			else if(result >= max)
				return max - 1;
			else
				return result;
		}

		public static System.Single GetSingle(	IRandom rand, 
												System.Single min = System.Single.MinValue, 
												System.Single max = System.Single.MaxValue)
		{
			byte[] buffer = new byte[4];
			rand.NextBytes(buffer);

			System.Single result = System.BitConverter.ToSingle(buffer, 0);

			if(result < min)
				return min;
			else if(result >= max)
				return max - 1;
			else
				return result;
		}

		public static System.Decimal GetDecimal(IRandom rand,
												System.Decimal min = System.Decimal.MinValue,
												System.Decimal max = System.Decimal.MaxValue)
		{
			System.Decimal result = new System.Decimal(rand.Next(), rand.Next(), rand.Next(), GetBoolean(rand), GetByte(rand, 0, 29));

			if(result < min)
				return min;
			else if (result >= max)
				return max - 1m;
			else 
				return result;
		}

		public static System.DateTime GetDateTime(	IRandom rand,
                                                    System.DateTime min,
                                                    System.DateTime max)
		{
			System.DateTime result = new System.DateTime(GetInt64(rand, min.Ticks, max.Ticks));

			if(result < min)
				return min;
			else if(result >= max)
				return new System.DateTime(max.Ticks - 1);
			else
				return result;
		}

		public static System.Guid GetGuid(IRandom rand)
		{
			byte[] buffer = new byte[16];
			rand.NextBytes(buffer);

			return new System.Guid(buffer);
		}

		public static System.Byte[] GetBinary(IRandom rand, int minLength, int maxLength)
		{
			int length = rand.Next(minLength, maxLength);
			byte[] result = new byte[length];
			rand.NextBytes(result);

			return result;
		}
	}
}