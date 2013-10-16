using NUnit.Framework;
using System.Collections.Generic;

namespace AutoPoco.KCL
{
	[TestFixture]
	public class BaseRandomDataSourceTests
	{
		#region Testing Dependencies

		private class DummyRandomDataSource : BaseRandomDataSource<int>
		{
			public IRandomExtensions GetRandom() { return Random; }

			public override int Next(AutoPoco.Engine.IGenerationContext session)
			{
				return Random.Next();
			}
		}

		#endregion

		[Test]
		public void Constructor_RandomPopulated()
		{
			DummyRandomDataSource source = new DummyRandomDataSource();
			Assert.IsNotNull(source.GetRandom(), @"
The Random Property on the abstract BaseRandomDataSource object should be populated after construction.
");
		}

		[Test]
		public void UsesSameSeed()
		{
			DummyRandomDataSource source1 = new DummyRandomDataSource();
			DummyRandomDataSource source2 = new DummyRandomDataSource();

			ICollection<int> collection1 = new List<int>();
			ICollection<int> collection2 = new List<int>();

			for(int i = 0; i < 1000; i++)
			{
				collection1.Add(source1.Next(null));
				collection2.Add(source2.Next(null));
			}

			CollectionAssert.AreEqual(collection1, collection2, @"
The two collections are not equal, suggesting that the two sources don't share the same seed on their 
pseudo-random number generator.
");
		}
	}
}