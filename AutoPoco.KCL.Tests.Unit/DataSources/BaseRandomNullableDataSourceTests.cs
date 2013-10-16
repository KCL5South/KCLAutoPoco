using NUnit.Framework;

namespace AutoPoco.KCL.DataSources
{
	[TestFixture]
	public class BaseRandomNullableDataSourceTests
	{
		#region Testing Dependencies

		private class DummyNullable : BaseRandomNullableDataSource<int>
		{
			public DummyNullable() : base() { }
			public DummyNullable(IRandomExtensions rand) : base(rand) { }

			protected override int NextValue(AutoPoco.Engine.IGenerationContext session)
			{
				return Random.Next();
			}
		}

		#endregion

		[Test]
		public void NullIsReturnedIfValueMod2IsZero()
		{
			TestRandom rand = new TestRandom();
			rand.IntQueue.Enqueue(1);
			rand.IntQueue.Enqueue(1);

			DummyNullable source = new DummyNullable(rand);

			Assert.IsNull(source.Next(null), "The value returned should be null because the random source returned zero.");
		}

		[Test]
		public void NonNullReturnedIfValueMod2IsOne()
		{
			TestRandom rand = new TestRandom();
			rand.IntQueue.Enqueue(0);
			rand.IntQueue.Enqueue(10);

			DummyNullable source = new DummyNullable(rand);

			Assert.IsNotNull(source.Next(null), "The value returned should not be null because the random source returned one.");
		}

		[Test]
		public void ValueReturnedIfValueMod2IsOne()
		{
			TestRandom rand = new TestRandom();
			rand.IntQueue.Enqueue(0);
			rand.IntQueue.Enqueue(1000);

			DummyNullable source = new DummyNullable(rand);

			Assert.AreEqual(1000, source.Next(null), "1000 was expected because it was the second item in the random queue.");
		}
	}
}