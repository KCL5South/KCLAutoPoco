using NUnit.Framework;
using Moq;

namespace AutoPoco.KCL.DataSources
{
	[TestFixture]
	public class RandomDecimalDataSourceTests
	{
		[Test]
		public void Constructor_RandIsSet()
		{
			IRandomExtensions rand = Mock.Of<IRandomExtensions>();
			var target = new RandomDecimalDataSource(rand);

			Assert.AreEqual(rand, target.Random, "The Random Property was not set properly.");
		}

		[Test]
		public void Next()
		{
			Mock<IRandomExtensions> randMock = new Mock<IRandomExtensions>();
			var target = new RandomDecimalDataSource(randMock.Object);
			target.Next(null);

			randMock.Verify(a => a.GetDecimal(System.Decimal.MinValue, System.Decimal.MaxValue), @"
The GetDecimal method on the IRandomExtensions object was not called.
");
		}
	}
}