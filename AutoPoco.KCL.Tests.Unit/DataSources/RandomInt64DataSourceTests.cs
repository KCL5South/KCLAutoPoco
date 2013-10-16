using NUnit.Framework;
using Moq;

namespace AutoPoco.KCL.DataSources
{
	[TestFixture]
	public class RandomInt64DataSourceTests
	{
		[Test]
		public void Constructor_RandIsSet()
		{
			IRandomExtensions rand = Mock.Of<IRandomExtensions>();
			var target = new RandomInt64DataSource(rand);

			Assert.AreEqual(rand, target.Random, "The Random Property was not set properly.");
		}

		[Test]
		public void Next()
		{
			Mock<IRandomExtensions> randMock = new Mock<IRandomExtensions>();
			var target = new RandomInt64DataSource(randMock.Object);
			target.Next(null);

			randMock.Verify(a => a.GetInt64(System.Int64.MinValue, System.Int64.MaxValue), @"
The GetInt64 method on the IRandomExtensions object was not called.
");
		}
	}
}