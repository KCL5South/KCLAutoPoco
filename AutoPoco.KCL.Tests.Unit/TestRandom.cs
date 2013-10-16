using System.Collections.Generic;
using NUnit.Framework;

namespace AutoPoco.KCL
{
	[TestFixture]
	internal class TestRandom : IRandom, IRandomExtensions
	{
		public Queue<int> IntQueue { get; private set; }
		public Queue<byte[]> ByteArrayQueue { get; private set; }
		public Queue<double> DoubleQueue { get; private set; }

		public TestRandom()
		{
			IntQueue = new Queue<int>();
			ByteArrayQueue = new Queue<byte[]>();
			DoubleQueue = new Queue<double>();
		}

		#region IRandom Members

		public int Next() { return IntQueue.Dequeue(); }
		public int Next(int maxValue) 
		{ 
			int result = IntQueue.Dequeue();
			if(result >= maxValue)
				return maxValue - 1;
			else
				return result;
		}
		public int Next(int minValue, int maxValue) 
		{ 
			int result = IntQueue.Dequeue();
			if(result >= maxValue)
				return maxValue - 1;
			else if(result < minValue)
				return minValue;
			else
				return result;
		}
		public void NextBytes(byte[] buffer)
		{
			byte[] value = ByteArrayQueue.Dequeue();
			for(int i = 0; i < buffer.Length; i++)
				buffer[i] = value[i];
		}
		public double NextDouble() { return DoubleQueue.Dequeue(); }

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

		[Test]
		public void NextReturnsTopOfIntQueue()
		{
			TestRandom rand = new TestRandom();
			rand.IntQueue.Enqueue(101);

			Assert.AreEqual(101, rand.Next(), "The result of Next should have been the top of the IntQueue");
		}
		[Test]
		public void NextPopsTheTopOfTheIntQueue()
		{
			TestRandom rand = new TestRandom();
			rand.IntQueue.Enqueue(0);

			if(rand.IntQueue.Count != 1)
				Assert.Fail("Unable to determine the size of IntQueue.");

			rand.Next();

			Assert.AreEqual(0, rand.IntQueue.Count, "The number of items left in IntQueue should be zero.");
		}
		[Test]
		public void NextDoubleReturnsTopOfDoubleQueue()
		{
			TestRandom rand = new TestRandom();
			rand.DoubleQueue.Enqueue(1.1);

			Assert.AreEqual(1.1, rand.NextDouble(), "The result of NextDouble should have been the top of the DoubleQueue.");
		}
		[Test]
		public void NextDoublePopsTheTopOfTheDoubleQueue()
		{
			TestRandom rand = new TestRandom();
			rand.DoubleQueue.Enqueue(1.2);

			if(rand.DoubleQueue.Count != 1)
				Assert.Fail("Unable to determine the size of DoubleQueue.");

			rand.NextDouble();

			Assert.AreEqual(0, rand.DoubleQueue.Count, "The number of items left in DoubleQueue should be zero.");
		}
		[Test]
		public void NextBytesReturnsTopOfBytesArrayQueue()
		{
			byte[] target = new byte[] { 0x1, 0x2, 0x3, 0x4 };
			TestRandom rand = new TestRandom();
			rand.ByteArrayQueue.Enqueue(target);

			byte[] result = new byte[4];
			rand.NextBytes(result);

			CollectionAssert.AreEqual(target, result, "The two arrays should be the same.");
		}
		[Test]
		public void NextBytesPopsTheTopOfTheBytesArrayQueue()
		{
			byte[] target = new byte[] { 0x1, 0x2, 0x3, 0x4 };
			TestRandom rand = new TestRandom();
			rand.ByteArrayQueue.Enqueue(target);

			if(rand.ByteArrayQueue.Count != 1)
				Assert.Fail("Unable to determine the size of ByteArrayQueue.");

			byte[] result = new byte[4];
			rand.NextBytes(result);

			Assert.AreEqual(0, rand.ByteArrayQueue.Count, "The number of items left in ByteArrayQueue should be zero.");
		}
		[Test]
		public void NextMaxReturnsNextItemInIntQueue()
		{
			TestRandom rand = new TestRandom();
			rand.IntQueue.Enqueue(100);

			int result = rand.Next(101);

			Assert.AreEqual(100, result);
		}
		[Test]
		public void NextMaxPopsIntQueue()
		{
			TestRandom rand = new TestRandom();
			rand.IntQueue.Enqueue(100);

			if(rand.IntQueue.Count != 1)
				Assert.Fail("Unable to determine the size of IntQueue.");

			rand.Next(101);

			Assert.AreEqual(0, rand.IntQueue.Count, "The number of items in IntQueue should be zero.");
		}
		[Test]
		public void NextMaxTruncatesValueInIntQueue()
		{
			TestRandom rand = new TestRandom();
			rand.IntQueue.Enqueue(101);
			int maxValue = 100;

			int result = rand.Next(maxValue);

			Assert.AreEqual(maxValue - 1, result, "The result should have been (maxvalue - 1) because the max value represents an exclusive upper bound.");	
		}
		[Test]
		public void NextMaxTruncatesValueInIntQueueAgain()
		{
			TestRandom rand = new TestRandom();
			int maxValue = 90;
			rand.IntQueue.Enqueue(maxValue);

			int result = rand.Next(maxValue);

			Assert.AreEqual(maxValue - 1, result, "The result should have been (maxvalue - 1) because the max value represents an exclusive upper bound.");	
		}
		[Test]
		public void NextMinMaxReturnsNextItemInIntQueue()
		{
			TestRandom rand = new TestRandom();
			rand.IntQueue.Enqueue(100);

			int result = rand.Next(0, 101);

			Assert.AreEqual(100, result);
		}
		[Test]
		public void NextMinMaxPopsIntQueue()
		{
			TestRandom rand = new TestRandom();
			rand.IntQueue.Enqueue(100);

			if(rand.IntQueue.Count != 1)
				Assert.Fail("Unable to determine the size of IntQueue.");

			rand.Next(0, 101);

			Assert.AreEqual(0, rand.IntQueue.Count, "The number of items in IntQueue should be zero.");
		}
		[Test]
		public void NextMinMaxTruncatesValueInIntQueueMax()
		{
			TestRandom rand = new TestRandom();
			rand.IntQueue.Enqueue(101);
			int maxValue = 100;

			int result = rand.Next(0, maxValue);

			Assert.AreEqual(maxValue - 1, result, "The result should have been (maxvalue - 1) because the max value represents an exclusive upper bound.");	
		}
		[Test]
		public void NextMinMaxTruncatesValueInIntQueueAgainMax()
		{
			TestRandom rand = new TestRandom();
			int maxValue = 90;
			rand.IntQueue.Enqueue(maxValue);

			int result = rand.Next(0, maxValue);

			Assert.AreEqual(maxValue - 1, result, "The result should have been (maxvalue - 1) because the max value represents an exclusive upper bound.");	
		}
		[Test]
		public void NextMinMaxTruncatesValueInIntQueueMin()
		{
			TestRandom rand = new TestRandom();
			rand.IntQueue.Enqueue(-1);
			int minValue = 0; 

			int result = rand.Next(minValue, 100);

			Assert.AreEqual(minValue, result, "The result should have been equal to minValue because the min value represents an inclusive lower bound.");	
		}
		[Test]
		public void NextMinMaxTruncatesValueInIntQueueAgainMin()
		{
			TestRandom rand = new TestRandom();
			int minValue = 5;
			rand.IntQueue.Enqueue(minValue);

			int result = rand.Next(minValue, 100);

			Assert.AreEqual(minValue, result, "The result should have been minValue because the min value represents an inclusive lower bound.");	
		}
	}	
}