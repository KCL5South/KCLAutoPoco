using AutoPoco.Configuration;
using AutoPoco.KCL.DataSources;

namespace AutoPoco.KCL.Conventions
{
	public class RandomNullableBooleanConvention : ITypePropertyConvention
	{
		#region ITypePropertyConvention Members

		public void Apply(ITypePropertyConventionContext context)
		{
			context.SetSource<RandomNullableBooleanDataSource>();
		}

		public void SpecifyRequirements(ITypeMemberConventionRequirements requirements)
		{
			requirements.Type(c => c == typeof(System.Nullable<bool>));
		}

		#endregion
	}
}