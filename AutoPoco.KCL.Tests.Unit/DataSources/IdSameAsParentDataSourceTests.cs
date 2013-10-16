using Moq;
using NUnit.Framework;
using AutoPoco;
using AutoPoco.Engine;
using AutoPoco.Configuration;

namespace AutoPoco.KCL.DataSources
{
	[TestFixture]
	public class IdSameAsParentDataSourceTests
	{
		#region Testing Dependencies

		private class TestModel
		{
			public System.Guid Id { get; set; }
		}

		private class DummyGenerationContextNode : IGenerationContextNode
		{
			public DummyGenerationContextNode(	GenerationTargetTypes type = GenerationTargetTypes.Object, 
											IGenerationContextNode parent = null)
			{
				ContextType = type;
				Parent = parent;
			}

			public GenerationTargetTypes ContextType { get; set; }
			public IGenerationContextNode Parent { get; set; }
		}

		#endregion		

		[Test]
		public void Constructor_IdExpressionSet()
		{
			IdSameAsParentDataSource<TestModel, System.Guid> source = new IdSameAsParentDataSource<TestModel, System.Guid>((a) => a.Id);

			TestModel model = new TestModel() { Id = System.Guid.NewGuid() };

			Assert.AreEqual(model.Id, source.IdExpression(model), @"
The expression that is used to find the id property of the parent was not set correctly in the data source object.
");
		}

		[Test]
		public void FindParent_NodeIsNull()
		{
			IdSameAsParentDataSource<TestModel, System.Guid> source = 
				new IdSameAsParentDataSource<TestModel, System.Guid>(a => a.Id);

			Assert.IsNull(source.FindParent(null), @"
The result from FindParent given a null node, should always return null.
");
		}

		[Test]
		public void FindParent_IfNotTypeGenerationContextNode_ReturnNull()
		{
			IdSameAsParentDataSource<TestModel, System.Guid> source = 
				new IdSameAsParentDataSource<TestModel, System.Guid>(a => a.Id);

			DummyGenerationContextNode node = new DummyGenerationContextNode();

			Assert.IsNull(source.FindParent(node), @"
FindParent should return null if the given node is not a TypeGenerationContextNode and it's Parent is null.
");
		}

		[Test]
		public void FindParent_IfIsTypeGeneratioNContextNode_AndParentNotType_ReturnNull()
		{
			IdSameAsParentDataSource<TestModel, System.Guid> source = 
				new IdSameAsParentDataSource<TestModel, System.Guid>(a => a.Id);

			TypeGenerationContextNode node = new TypeGenerationContextNode(null, "Test Object as String");

			Assert.IsNull(source.FindParent(node), @"
FindParent should return null if the given node is a TypeGenerationContextNode but it's Target is not of the given type.
");
		}

		[Test]
		public void FindParent_IfIsTypeGenerationContextNode_AndParentIsType_ReturnParent()
		{
			TestModel target = new TestModel();
			IdSameAsParentDataSource<TestModel, System.Guid> source = 
				new IdSameAsParentDataSource<TestModel, System.Guid>(a => a.Id);

			TypeGenerationContextNode node = new TypeGenerationContextNode(null, target);

			Assert.AreEqual(target, source.FindParent(node), @"
FindParent should return it's Target if the given node is a TypeGenerationContextNode and it's Target is of the
specified type.
");
		}

		[Test]
		public void FindParent_NestedTest()
		{
			TestModel target = new TestModel();
			IdSameAsParentDataSource<TestModel, System.Guid> source = 
				new IdSameAsParentDataSource<TestModel, System.Guid>(a => a.Id);

			DummyGenerationContextNode root = new DummyGenerationContextNode();
			TypeGenerationContextNode targetNode = new TypeGenerationContextNode(root, target);
			DummyGenerationContextNode leafNode = new DummyGenerationContextNode(GenerationTargetTypes.Object, targetNode);

			Assert.AreEqual(target, source.FindParent(leafNode), @"
Target should have been returned.  A TypeGenerationContextNode with a Target of type TestModel was the parent of the node passed to FindParent.
");
		}

		[Test]
		public void Next_NullParent_ReturnDefault()
		{
			IdSameAsParentDataSource<TestModel, System.Guid> source = 
				new IdSameAsParentDataSource<TestModel, System.Guid>(a => a.Id);

			DummyGenerationContextNode node = new DummyGenerationContextNode();
			Mock<IGenerationContext> contextMock = new Mock<IGenerationContext>();
			contextMock.Setup(a => a.Node).Returns(node);

			Assert.AreEqual(default(System.Guid), source.Next(contextMock.Object), @"
The result of Next should be {0} because the parent was not found.
", default(System.Guid));
		}

		[Test]
		public void Next()
		{
			TestModel target = new TestModel() { Id = System.Guid.NewGuid() };
			IdSameAsParentDataSource<TestModel, System.Guid> source = 
				new IdSameAsParentDataSource<TestModel, System.Guid>(a => a.Id);

			TypeGenerationContextNode node = new TypeGenerationContextNode(null, target);
			Mock<IGenerationContext> contextMock = new Mock<IGenerationContext>();
			contextMock.Setup(a => a.Node).Returns(node);

			Assert.AreEqual(target.Id, source.Next(contextMock.Object), @"
The result should be the value of the Id property of our target.
");
		}
	}
}