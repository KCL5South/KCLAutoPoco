using NUnit.Framework;
using Moq;
using AutoPoco.Configuration;
using AutoPoco.Engine;
using AutoPoco.KCL.DataSources;
using System.Linq;

namespace AutoPoco.KCL.Conventions
{
	[TestFixture]
	public class RandomInt16ConventionTests
	{
		[Test]
		public void Apply()
		{
			Mock<ITypePropertyConventionContext> contextMock = new Mock<ITypePropertyConventionContext>();
			var target = new RandomInt16Convention();

			target.Apply(contextMock.Object);

			contextMock.Verify( a => a.SetSource<RandomInt16DataSource>(), @"
The SetSource method was not called on the TypePropertyConvenctionContext object.
This has to happen in order for the convention to work.
");
		}

		[Test]
		public void SpecifyRequirements()
		{
			Mock<ITypeMemberConventionRequirements> reqMock = new Mock<ITypeMemberConventionRequirements>();
			var target = new RandomInt16Convention();

			target.SpecifyRequirements(reqMock.Object);

			reqMock.Verify(a => a.Type(x => x == typeof(short)), @"
The SpecifyRequirements call produced a requirement that doesn't make sense for this convention.
");
		}

		private class TestClass
		{
			public short TargetProperty { get; set; }
		}

		[Test]
		public void IntegrationTest()
		{
			var mFactory = AutoPocoContainer.Configure(x =>
			{
				x.Conventions(c =>
				{
					c.Register<RandomInt16Convention>();
					c.UseDefaultConventions();
				});
			});

			IGenerationSession session = mFactory.CreateSession();

			var targets = session.List<TestClass>(100).Get()
				.Select(a => a.TargetProperty);

			CollectionAssert.AreNotEqual(targets.Take(5), targets.Skip(5), @"
The Convention Registration did not take.  A produced set of models were all equal.
");
		}
	}
}