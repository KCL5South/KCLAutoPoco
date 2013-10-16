using NUnit.Framework;
using Moq;

namespace AutoPoco.KCL.DataSources
{
	[TestFixture]
	public class RandomNullableInt16DataSourceTests
	{
		#region Testing Dependencies

		private class DummyDataSource : RandomNullableInt16DataSource
		{
			public DummyDataSource(IRandomExtensions rand) : base(rand) { }
			public System.Int16 PublicNextValue()
			{
				return this.NextValue(null);
			}
		}

		#endregion

		[Test]
		public void Constructor_RandIsSet()
		{
			IRandomExtensions rand = Mock.Of<IRandomExtensions>();
			var target = new RandomNullableInt16DataSource(rand);

			Assert.AreEqual(rand, target.Random, "The Random Property was not set properly.");
		}

		[Test]
		public void NextValue()
		{
			Mock<IRandomExtensions> randMock = new Mock<IRandomExtensions>();
			var target = new DummyDataSource(randMock.Object);

			target.PublicNextValue();

			randMock.Verify(a => a.GetInt16(System.Int16.MinValue, System.Int16.MaxValue), @"
GetInt16 was not called on the Random Extensions object.
");
		}
	}
}