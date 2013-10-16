using NUnit.Framework;
using Moq;

namespace AutoPoco.KCL.DataSources
{
	[TestFixture]
	public class RandomInt16DataSourceTests
	{
		[Test]
		public void Constructor_RandIsSet()
		{
			IRandomExtensions rand = Mock.Of<IRandomExtensions>();
			var target = new RandomInt16DataSource(rand);

			Assert.AreEqual(rand, target.Random, "The Random Property was not set properly.");
		}

		[Test]
		public void Next()
		{
			Mock<IRandomExtensions> randMock = new Mock<IRandomExtensions>();
			var target = new RandomInt16DataSource(randMock.Object);
			target.Next(null);

			randMock.Verify(a => a.GetInt16(System.Int16.MinValue, System.Int16.MaxValue), @"
The GetInt16 method on the IRandomExtensions object was not called.
");
		}
	}
}