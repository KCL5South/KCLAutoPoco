using NUnit.Framework;
using Moq;

namespace AutoPoco.KCL.DataSources
{
	[TestFixture]
	public class RandomByteDataSourceTests
	{
		[Test]
		public void Constructor_RandIsSet()
		{
			IRandomExtensions rand = Mock.Of<IRandomExtensions>();
			var target = new RandomByteDataSource(rand);

			Assert.AreEqual(rand, target.Random, "The Random Property was not set properly.");
		}

		[Test]
		public void Next()
		{
			Mock<IRandomExtensions> randMock = new Mock<IRandomExtensions>();
			var target = new RandomByteDataSource(randMock.Object);
			target.Next(null);

			randMock.Verify(a => a.GetByte(System.Byte.MinValue, System.Byte.MaxValue), @"
The GetByte method on the IRandomExtensions object was not called.
");
		}
	}
}