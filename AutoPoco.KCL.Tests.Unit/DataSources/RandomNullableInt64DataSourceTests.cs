using NUnit.Framework;
using Moq;

namespace AutoPoco.KCL.DataSources
{
	[TestFixture]
	public class RandomNullableInt64DataSourceTests
	{
		#region Testing Dependencies

		private class DummyDataSource : RandomNullableInt64DataSource
		{
			public DummyDataSource(IRandomExtensions rand) : base(rand) { }
			public System.Int64 PublicNextValue()
			{
				return this.NextValue(null);
			}
		}

		#endregion

		[Test]
		public void Constructor_RandIsSet()
		{
			IRandomExtensions rand = Mock.Of<IRandomExtensions>();
			var target = new RandomNullableInt64DataSource(rand);

			Assert.AreEqual(rand, target.Random, "The Random Property was not set properly.");
		}

		[Test]
		public void NextValue()
		{
			Mock<IRandomExtensions> randMock = new Mock<IRandomExtensions>();
			var target = new DummyDataSource(randMock.Object);

			target.PublicNextValue();

			randMock.Verify(a => a.GetInt64(System.Int64.MinValue, System.Int64.MaxValue), @"
GetInt64 was not called on the Random Extensions object.
");
		}
	}
}