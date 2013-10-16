using NUnit.Framework;
using Moq;

namespace AutoPoco.KCL.DataSources
{
	[TestFixture]
	public class RandomNullableBooleanDataSourceTests
	{
		#region Testing Dependencies

		private class DummyDataSource : RandomNullableBooleanDataSource
		{
			public DummyDataSource(IRandomExtensions rand) : base(rand) { }
			public System.Boolean PublicNextValue()
			{
				return this.NextValue(null);
			}
		}

		#endregion

		[Test]
		public void Constructor_RandIsSet()
		{
			IRandomExtensions rand = Mock.Of<IRandomExtensions>();
			var target = new RandomNullableBooleanDataSource(rand);

			Assert.AreEqual(rand, target.Random, "The Random Property was not set properly.");
		}

		[Test]
		public void NextValue()
		{
			Mock<IRandomExtensions> randMock = new Mock<IRandomExtensions>();
			var target = new DummyDataSource(randMock.Object);

			target.PublicNextValue();

			randMock.Verify(a => a.GetBoolean(), @"
GetBoolean was not called on the Random Extensions object.
");
		}
	}
}