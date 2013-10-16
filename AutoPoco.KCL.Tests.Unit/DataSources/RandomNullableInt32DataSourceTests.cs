using NUnit.Framework;
using Moq;

namespace AutoPoco.KCL.DataSources
{
	[TestFixture]
	public class RandomNullableInt32DataSourceTests
	{
		#region Testing Dependencies

		private class DummyDataSource : RandomNullableInt32DataSource
		{
			public DummyDataSource(IRandomExtensions rand) : base(rand) { }
			public System.Int32 PublicNextValue()
			{
				return this.NextValue(null);
			}
		}

		#endregion

		[Test]
		public void Constructor_RandIsSet()
		{
			IRandomExtensions rand = Mock.Of<IRandomExtensions>();
			var target = new RandomNullableInt32DataSource(rand);

			Assert.AreEqual(rand, target.Random, "The Random Property was not set properly.");
		}

		[Test]
		public void NextValue()
		{
			Mock<IRandomExtensions> randMock = new Mock<IRandomExtensions>();
			var target = new DummyDataSource(randMock.Object);

			target.PublicNextValue();

			randMock.Verify(a => a.GetInt32(System.Int32.MinValue, System.Int32.MaxValue), @"
GetInt32 was not called on the Random Extensions object.
");
		}
	}
}