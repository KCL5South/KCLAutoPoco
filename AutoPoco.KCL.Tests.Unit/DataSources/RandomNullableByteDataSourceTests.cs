using NUnit.Framework;
using Moq;

namespace AutoPoco.KCL.DataSources
{
	[TestFixture]
	public class RandomNullableByteDataSourceTests
	{
		#region Testing Dependencies

		private class DummyDataSource : RandomNullableByteDataSource
		{
			public DummyDataSource(IRandomExtensions rand) : base(rand) { }
			public System.Byte PublicNextValue()
			{
				return this.NextValue(null);
			}
		}

		#endregion

		[Test]
		public void Constructor_RandIsSet()
		{
			IRandomExtensions rand = Mock.Of<IRandomExtensions>();
			var target = new RandomNullableByteDataSource(rand);

			Assert.AreEqual(rand, target.Random, "The Random Property was not set properly.");
		}

		[Test]
		public void NextValue()
		{
			Mock<IRandomExtensions> randMock = new Mock<IRandomExtensions>();
			var target = new DummyDataSource(randMock.Object);

			target.PublicNextValue();

			randMock.Verify(a => a.GetByte(System.Byte.MinValue, System.Byte.MaxValue), @"
GetByte was not called on the Random Extensions object.
");
		}
	}
}