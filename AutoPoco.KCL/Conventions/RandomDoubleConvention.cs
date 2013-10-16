using AutoPoco.Configuration;
using AutoPoco.KCL.DataSources;

namespace AutoPoco.KCL.Conventions
{
	public class RandomDoubleConvention : ITypePropertyConvention
	{
		#region ITypePropertyConvention Members

		public void Apply(ITypePropertyConventionContext context)
		{
			context.SetSource<RandomDoubleDataSource>();
		}

		public void SpecifyRequirements(ITypeMemberConventionRequirements requirements)
		{
			requirements.Type(c => c == typeof(double));
		}

		#endregion
	}
}