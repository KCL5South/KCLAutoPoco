using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace AutoPoco.KCL
{
	[TestFixture]
	public class RandomExtensionsTests
	{
		//------------------------------------------
		//GetBoolean()
		//------------------------------------------
		[Test]
		public void GetBoolean_True()
		{
			TestRandom rand = new TestRandom();
			rand.IntQueue.Enqueue(1);

			Assert.IsTrue(rand.GetBoolean());
		}
		[Test]
		public void GetBoolean_False()
		{
			TestRandom rand = new TestRandom();
			rand.IntQueue.Enqueue(0);
			Assert.IsFalse(rand.GetBoolean());
		}

		//------------------------------------------
		//GetByte()
		//------------------------------------------
		[Test]
		[TestCase(1)]
		[TestCase(System.Byte.MinValue)]
		[TestCase(System.Byte.MaxValue - 1)]
		public void GetByte(int target)
		{
			TestRandom rand = new TestRandom();
			rand.IntQueue.Enqueue(target);
			Assert.AreEqual(target, rand.GetByte());
		}
		[Test]
		public void GetByte_MinIsTruncated_Inclusive()
		{
			TestRandom rand = new TestRandom();
			rand.IntQueue.Enqueue(5);
			Assert.AreEqual(6, rand.GetByte(6, 10));
		}
		[Test]
		public void GetByte_MaxIsTruncated_Exclusive()
		{
			TestRandom rand = new TestRandom();
			rand.IntQueue.Enqueue(10);
			Assert.AreEqual(9, rand.GetByte(5, 10));
		}
		//------------------------------------------
		//GetInt16()
		//------------------------------------------
		[Test]
		[TestCase(1)]
		[TestCase(0)]
		[TestCase(-1)]
		[TestCase(System.Int16.MinValue)]
		[TestCase(System.Int16.MaxValue - 1)]
		public void GetInt16(int target)
		{
			TestRandom rand = new TestRandom();
			rand.IntQueue.Enqueue(target);
			Assert.AreEqual(target, rand.GetInt16());
		}
		[Test]
		public void GetInt16_MinIsTruncated_Inclusive()
		{
			TestRandom rand = new TestRandom();
			rand.IntQueue.Enqueue(5);
			Assert.AreEqual(6, rand.GetInt16(6, 10));
		}
		[Test]
		public void GetInt16_MaxIsTruncated_Exclusive()
		{
			TestRandom rand = new TestRandom();
			rand.IntQueue.Enqueue(10);
			Assert.AreEqual(9, rand.GetInt16(5, 10));
		}
		//------------------------------------------
		//GetInt32()
		//------------------------------------------
		[Test]
		[TestCase(1)]
		[TestCase(0)]
		[TestCase(-1)]
		[TestCase(System.Int32.MinValue)]
		[TestCase(System.Int32.MaxValue - 1)]
		public void GetInt32(int target)
		{
			TestRandom rand = new TestRandom();
			rand.IntQueue.Enqueue(target);
			Assert.AreEqual(target, rand.GetInt32());
		}
		[Test]
		public void GetInt32_MinIsTruncated_Inclusive()
		{
			TestRandom rand = new TestRandom();
			rand.IntQueue.Enqueue(5);
			Assert.AreEqual(6, rand.GetInt32(6, 10));
		}
		[Test]
		public void GetInt32_MaxIsTruncated_Exclusive()
		{
			TestRandom rand = new TestRandom();
			rand.IntQueue.Enqueue(10);
			Assert.AreEqual(9, rand.GetInt32(5, 10));
		}
		//------------------------------------------
		//GetInt64()
		//------------------------------------------
		[Test]
		[TestCase(1)]
		[TestCase(0)]
		[TestCase(-1)]
		[TestCase(System.Int64.MinValue)]
		[TestCase(System.Int64.MaxValue - 1)]
		public void GetInt64(System.Int64 target)
		{
			TestRandom rand = new TestRandom();
			rand.ByteArrayQueue.Enqueue(System.BitConverter.GetBytes(target));

			Assert.AreEqual(target, rand.GetInt64());
		}
		[Test]
		public void GetInt64_MinIsTruncated_Inclusive()
		{
			TestRandom rand = new TestRandom();
			rand.ByteArrayQueue.Enqueue(System.BitConverter.GetBytes(5L));
			Assert.AreEqual(6L, rand.GetInt64(6, 10));
		}
		[Test]
		public void GetInt64_MaxIsTruncated_Exclusive()
		{
			TestRandom rand = new TestRandom();
			rand.ByteArrayQueue.Enqueue(System.BitConverter.GetBytes(10L));
			Assert.AreEqual(9L, rand.GetInt64(5, 10));
		}
		//------------------------------------------
		//GetDouble()
		//------------------------------------------
		[Test]
		[TestCase(1.0)]
		[TestCase(0.0)]
		[TestCase(-1.0)]
		[TestCase(System.Double.MinValue)]
		[TestCase(System.Double.MaxValue - 1.0)]
		public void GetDouble(System.Double target)
		{
			TestRandom rand = new TestRandom();
			rand.ByteArrayQueue.Enqueue(System.BitConverter.GetBytes(target));

			Assert.AreEqual(target, rand.GetDouble());
		}
		[Test]
		public void GetDouble_MinIsTruncated_Inclusive()
		{
			TestRandom rand = new TestRandom();
			rand.ByteArrayQueue.Enqueue(System.BitConverter.GetBytes(5.0));
			Assert.AreEqual(6.0, rand.GetDouble(6, 10));
		}
		[Test]
		public void GetDouble_MaxIsTruncated_Exclusive()
		{
			TestRandom rand = new TestRandom();
			rand.ByteArrayQueue.Enqueue(System.BitConverter.GetBytes(10.0));
			Assert.AreEqual(9.0, rand.GetDouble(5, 10));
		}
		//------------------------------------------
		//GetSingle()
		//------------------------------------------
		[Test]
		[TestCase(1.0f)]
		[TestCase(0.0f)]
		[TestCase(-1.0f)]
		[TestCase(System.Single.MinValue)]
		[TestCase(System.Single.MaxValue - 1.0f)]
		public void GetSingle(System.Single target)
		{
			TestRandom rand = new TestRandom();
			rand.ByteArrayQueue.Enqueue(System.BitConverter.GetBytes(target));

			Assert.AreEqual(target, rand.GetSingle());
		}
		[Test]
		public void GetSingle_MinIsTruncated_Inclusive()
		{
			TestRandom rand = new TestRandom();
			rand.ByteArrayQueue.Enqueue(System.BitConverter.GetBytes(5.0f));
			Assert.AreEqual(6.0f, rand.GetSingle(6f, 10f));
		}
		[Test]
		public void GetSingle_MaxIsTruncated_Exclusive()
		{
			TestRandom rand = new TestRandom();
			rand.ByteArrayQueue.Enqueue(System.BitConverter.GetBytes(10.0f));
			Assert.AreEqual(9.0f, rand.GetSingle(5f, 10f));
		}
		//------------------------------------------
		//GetDecimal()
		//------------------------------------------
		private IEnumerable<int> GetUsableDecimalBits(System.Decimal target)
		{
			int[] bits = System.Decimal.GetBits(target);
			yield return bits[0];
			yield return bits[1];
			yield return bits[2];
			yield return (bits[3] >> 31) & 0x00000001;
			yield return (bits[3] >> 16) & 0x00000011;
		}
		public static IEnumerable<System.Decimal> GetDecimal_TestCases()
		{
			yield return 1m;
			yield return 0m;
			yield return -1m;
			yield return System.Decimal.MinValue;
			yield return System.Decimal.MaxValue - 1m;
		}
		[Test]
		[TestCaseSource("GetDecimal_TestCases")]
		public void GetDecimal(System.Decimal target)
		{
			TestRandom rand = new TestRandom();
			foreach(var item in GetUsableDecimalBits(target))
				rand.IntQueue.Enqueue(item);

			Assert.AreEqual(target, rand.GetDecimal());
		}
		[Test]
		public void GetDecimal_MinIsTruncated_Inclusive()
		{
			TestRandom rand = new TestRandom();
			foreach(var item in GetUsableDecimalBits(5m))
				rand.IntQueue.Enqueue(item);
			Assert.AreEqual(6m, rand.GetDecimal(6m, 10m));
		}
		[Test]
		public void GetDecimal_MaxIsTruncated_Exclusive()
		{
			TestRandom rand = new TestRandom();
			foreach(var item in GetUsableDecimalBits(10m))
				rand.IntQueue.Enqueue(item);
			Assert.AreEqual(9m, rand.GetDecimal(5m, 10m));
		}
		[Test]
		[TestCase(1, 1, 1, 0, 0, 0)]
		[TestCase(1, 1, 1, 0, 28, 28)]
		[TestCase(1, 1, 1, 0, 0, -1)]
		[TestCase(1, 1, 1, 0, 28, 29)]
		public void GetDecimalScaleMustBeBetween0And28Inclusive(int low, int mid, int high, int signed, int scale, int badScale)
		{
			TestRandom rand = new TestRandom();
			rand.IntQueue.Enqueue(low);
			rand.IntQueue.Enqueue(mid);
			rand.IntQueue.Enqueue(high);
			rand.IntQueue.Enqueue(signed);
			rand.IntQueue.Enqueue(badScale);

			Assert.AreEqual(new System.Decimal(low, mid, high, (signed % 2) == 1, (byte)scale), rand.GetDecimal(), @"
The two decimal values should be equal.
");
		}
		//------------------------------------------
		//GetDateTime()
		//------------------------------------------
		public static IEnumerable<System.DateTime> GetDateTimeTestCases()
		{
			yield return System.DateTime.MinValue;
			yield return new System.DateTime(System.DateTime.MaxValue.Year,
												System.DateTime.MaxValue.Month,
												System.DateTime.MaxValue.Day,
												System.DateTime.MaxValue.Hour,
												System.DateTime.MaxValue.Minute,
												System.DateTime.MaxValue.Second,
												System.DateTime.MaxValue.Millisecond - 1);
			yield return new System.DateTime(1980, 6, 17, 7, 30, 30, 0);
			yield return new System.DateTime(2010, 8, 19, 14, 40, 0, 0);
		}

		[Test]
		[TestCaseSource("GetDateTimeTestCases")]
		public void GetDateTime(System.DateTime target)
		{
			TestRandom rand = new TestRandom();
			rand.ByteArrayQueue.Enqueue(System.BitConverter.GetBytes(target.Ticks));

			Assert.AreEqual(target, rand.GetDateTime(System.DateTime.MinValue, System.DateTime.MaxValue));
		}
		[Test]
		public void GetDateTime_MinIsTruncated_Inclusive()
		{
			System.DateTime min = new System.DateTime(1000, 1, 1, 0, 0, 0, 1);
			System.DateTime target = new System.DateTime(min.Year, min.Month, min.Day, min.Hour, min.Minute, min.Second, min.Millisecond - 1);

			TestRandom rand = new TestRandom();
			rand.ByteArrayQueue.Enqueue(System.BitConverter.GetBytes(target.Ticks));

			Assert.AreEqual(min, rand.GetDateTime(min, System.DateTime.MaxValue));
		}
		[Test]
		public void GetDateTime_MaxIsTruncated_Exclusive()
		{
			System.DateTime max = new System.DateTime(1000, 1, 1, 0, 0, 0, 1);
			System.DateTime target = new System.DateTime(max.Ticks - 1);

			TestRandom rand = new TestRandom();
			rand.ByteArrayQueue.Enqueue(System.BitConverter.GetBytes(max.Ticks));

			Assert.AreEqual(target, rand.GetDateTime(System.DateTime.MinValue, max));
		}
		//------------------------------------------
		//GetGuid()
		//------------------------------------------
		public static IEnumerable<byte[]> GetGuid_TestCaseSource()
		{
			yield return new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
			yield return new byte[] { 1, 3, 5, 7, 11, 13, 17, 19, 23, 23, 23, 23, 23, 23, 23, 23 };
			yield return new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
			yield return new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
		}
		[Test]
		[TestCaseSource("GetGuid_TestCaseSource")]
		public void GetGuid(byte[] targetBytes)
		{
			System.Guid target = new System.Guid(targetBytes);
			TestRandom rand = new TestRandom();
			rand.ByteArrayQueue.Enqueue(targetBytes);

			Assert.AreEqual(target, rand.GetGuid());
		}
		//------------------------------------------
		//GetBinary()
		//------------------------------------------
		public IEnumerable<object[]> GetBinaryTestCases()
		{
			yield return new object[] { 1, 10, 3, new byte[] { 0x01, 0x02, 0x03 } };
			yield return new object[] { 2, 10, 4, new byte[] { 0x01, 0x02, 0x03, 0x04 } };
			yield return new object[] { 3, 11, 5, new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05 } };
			yield return new object[] { 5, 100, 6, new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06 } };
		}
		[Test]
		[TestCaseSource("GetBinaryTestCases")]
		public void GetBinaryTests(int min, int max, int length, byte[] data)
		{
			TestRandom rand = new TestRandom();
			rand.ByteArrayQueue.Enqueue(data);
			rand.IntQueue.Enqueue(length);

			CollectionAssert.AreEqual(data, rand.GetBinary(min, max));
		}
		[Test]
		public void GetBinary_MinTruncates_Inclusive()
		{
			TestRandom rand = new TestRandom();
			rand.ByteArrayQueue.Enqueue(new byte[] { 0, 1, 2 });
			rand.IntQueue.Enqueue(2);

			CollectionAssert.AreEqual(new byte[] { 0, 1, 2 }, rand.GetBinary(3, 4));
		}
		[Test]
		public void GetBinary_MaxTruncates_Exclusive()
		{
			TestRandom rand = new TestRandom();
			rand.ByteArrayQueue.Enqueue(new byte[] { 1, 2, 3, 4 });
			rand.IntQueue.Enqueue(5);

			CollectionAssert.AreEqual(new byte[] { 1, 2, 3, 4 }, rand.GetBinary(3, 5));
		}
	}
}