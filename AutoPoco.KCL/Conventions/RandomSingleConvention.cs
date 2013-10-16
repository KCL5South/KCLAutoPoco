using AutoPoco.Configuration;
using AutoPoco.KCL.DataSources;

namespace AutoPoco.KCL.Conventions
{
	public class RandomSingleConvention : ITypePropertyConvention
	{
		#region ITypePropertyConvention Members

		public void Apply(ITypePropertyConventionContext context)
		{
			context.SetSource<RandomSingleDataSource>();
		}

		public void SpecifyRequirements(ITypeMemberConventionRequirements requirements)
		{
			requirements.Type(c => c == typeof(float));
		}

		#endregion
	}
}