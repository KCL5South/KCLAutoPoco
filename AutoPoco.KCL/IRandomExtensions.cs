namespace AutoPoco.KCL
{
	public interface IRandomExtensions : IRandom
	{
		System.Boolean GetBoolean();
		System.Byte GetByte(System.Byte min = System.Byte.MinValue, System.Byte max = System.Byte.MaxValue);
		System.Int16 GetInt16(System.Int16 min = System.Int16.MinValue, System.Int16 max = System.Int16.MaxValue);
		System.Int32 GetInt32(System.Int32 min = System.Int32.MinValue, System.Int32 max = System.Int32.MaxValue);
		System.Int64 GetInt64(System.Int64 min = System.Int64.MinValue, System.Int64 max = System.Int64.MaxValue);
		System.Double GetDouble(System.Double min = System.Double.MinValue, System.Double max = System.Double.MaxValue);
		System.Single GetSingle(System.Single min = System.Single.MinValue, System.Single max = System.Single.MaxValue);
		System.Decimal GetDecimal(System.Decimal min = System.Decimal.MinValue, System.Decimal max = System.Decimal.MaxValue);
		System.DateTime GetDateTime(System.DateTime min, System.DateTime max);
		System.Guid GetGuid();
		System.Byte[] GetBinary(int minLength, int maxLength);
	}
}