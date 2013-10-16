using System;
using AutoPoco.Engine;
using AutoPoco;
namespace AutoPoco.KCL.DataSources
{
	public class IdSameAsParentDataSource<TParent, TId> : DatasourceBase<TId>
		where TParent : class
    {
        public Func<TParent, TId> IdExpression { get; private set; }

        public IdSameAsParentDataSource(Func<TParent, TId> ex)
        {
            IdExpression = ex;
        }

        public override TId Next(IGenerationContext session)
        {
            TParent parent = FindParent(session.Node);
            if (parent == null)
                return default(TId);
            else
                return IdExpression(parent);
        }

        public TParent FindParent(IGenerationContextNode node)
        {
            if (node == null)
                return null;

            TypeGenerationContextNode tgNode = node as TypeGenerationContextNode;
            if (tgNode == null)
                return FindParent(node.Parent);
            else
            {
                if (tgNode.Target is TParent)
                    return (TParent)tgNode.Target;
                else
                    return FindParent(node.Parent);
            }
        }
    }
}