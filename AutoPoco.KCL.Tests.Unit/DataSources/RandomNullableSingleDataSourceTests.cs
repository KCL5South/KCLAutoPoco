using NUnit.Framework;
using Moq;

namespace AutoPoco.KCL.DataSources
{
	[TestFixture]
	public class RandomNullableSingleDataSourceTests
	{
		#region Testing Dependencies

		private class DummyDataSource : RandomNullableSingleDataSource
		{
			public DummyDataSource(IRandomExtensions rand) : base(rand) { }
			public System.Single PublicNextValue()
			{
				return this.NextValue(null);
			}
		}

		#endregion

		[Test]
		public void Constructor_RandIsSet()
		{
			IRandomExtensions rand = Mock.Of<IRandomExtensions>();
			var target = new RandomNullableSingleDataSource(rand);

			Assert.AreEqual(rand, target.Random, "The Random Property was not set properly.");
		}

		[Test]
		public void NextValue()
		{
			Mock<IRandomExtensions> randMock = new Mock<IRandomExtensions>();
			var target = new DummyDataSource(randMock.Object);

			target.PublicNextValue();

			randMock.Verify(a => a.GetSingle(System.Single.MinValue, System.Single.MaxValue), @"
GetSingle was not called on the Random Extensions object.
");
		}
	}
}