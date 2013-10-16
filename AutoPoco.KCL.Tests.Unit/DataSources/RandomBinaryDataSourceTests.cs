using NUnit.Framework;
using Moq;

namespace AutoPoco.KCL.DataSources
{
	[TestFixture]
	public class RandomBinaryDataSourceTests
	{
		[Test]
		public void Constructor_MinLengthSet()
		{
			RandomBinaryDataSource source = new RandomBinaryDataSource(1, 2);
			Assert.AreEqual(1, source.MinLength);
		}
		[Test]
		public void Constructor_MinLengthSetAgain()
		{
			RandomBinaryDataSource source = new RandomBinaryDataSource(10, 11);
			Assert.AreEqual(10, source.MinLength);
		}
		[Test]
		public void Constructor_MaxLengthSet()
		{
			RandomBinaryDataSource source = new RandomBinaryDataSource(0, 1);
			Assert.AreEqual(1, source.MaxLength);
		}
		[Test]
		public void Constructor_MaxLengthSetAgain()
		{
			RandomBinaryDataSource source = new RandomBinaryDataSource(0, 10);
			Assert.AreEqual(10, source.MaxLength);
		}
		[Test]
		public void Constructor_RandIsSet()
		{
			IRandomExtensions rand = Mock.Of<IRandomExtensions>();
			var target = new RandomBinaryDataSource(rand, 1, 2);

			Assert.AreEqual(rand, target.Random, "The Random Property was not set properly.");
		}
		[Test]
		public void Constructor_MaxLengthLessThanMin()
		{
			try
			{
				new RandomBinaryDataSource(2, 1);
				Assert.Fail("An ArgumentException was expected because the MaxLength value was less than MinLength");
			}
			catch (System.ArgumentException) { }
		}
		[Test]
		public void Constructor_MaxLengthLessThanMin_WithRand()
		{
			try
			{
				new RandomBinaryDataSource(Mock.Of<IRandomExtensions>(), 2, 1);
				Assert.Fail("An ArgumentException was expected because the MaxLength value was less than MinLength");
			}
			catch (System.ArgumentException) { }
		}
		[Test]
		public void Next()
		{
			Mock<IRandomExtensions> randMock = new Mock<IRandomExtensions>();
			var target = new RandomBinaryDataSource(randMock.Object, 1, 2);
			target.Next(null);

			randMock.Verify(a => a.GetBinary(1, 2), @"
The GetBinary method on the IRandomExtensions object was not called.
");
		}
	}
}