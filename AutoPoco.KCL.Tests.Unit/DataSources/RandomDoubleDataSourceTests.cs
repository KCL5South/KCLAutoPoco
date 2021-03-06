using NUnit.Framework;
using Moq;

namespace AutoPoco.KCL.DataSources
{
	[TestFixture]
	public class RandomDoubleDataSourceTests
	{
		[Test]
		public void Constructor_RandIsSet()
		{
			IRandomExtensions rand = Mock.Of<IRandomExtensions>();
			var target = new RandomDoubleDataSource(rand);

			Assert.AreEqual(rand, target.Random, "The Random Property was not set properly.");
		}

		[Test]
		public void Next()
		{
			Mock<IRandomExtensions> randMock = new Mock<IRandomExtensions>();
			var target = new RandomDoubleDataSource(randMock.Object);
			target.Next(null);

			randMock.Verify(a => a.GetDouble(System.Double.MinValue, System.Double.MaxValue), @"
The GetDouble method on the IRandomExtensions object was not called.
");
		}
	}
}