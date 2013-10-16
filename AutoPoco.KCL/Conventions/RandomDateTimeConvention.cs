using AutoPoco.Configuration;
using AutoPoco.KCL.DataSources;

namespace AutoPoco.KCL.Conventions
{
	public class RandomDateTimeConvention : ITypePropertyConvention
	{
		#region ITypePropertyConvention Members

		public void Apply(ITypePropertyConventionContext context)
		{
			context.SetSource<RandomDateTimeDataSource>();
		}

		public void SpecifyRequirements(ITypeMemberConventionRequirements requirements)
		{
			requirements.Type(c => c == typeof(System.DateTime));
		}

		#endregion
	}
}