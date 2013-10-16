using AutoPoco.Configuration;
using AutoPoco.KCL.DataSources;

namespace AutoPoco.KCL.Conventions
{
	public class RandomNullableSingleConvention : ITypePropertyConvention
	{
		#region ITypePropertyConvention Members

		public void Apply(ITypePropertyConventionContext context)
		{
			context.SetSource<RandomNullableSingleDataSource>();
		}

		public void SpecifyRequirements(ITypeMemberConventionRequirements requirements)
		{
			requirements.Type(c => c == typeof(System.Nullable<float>));
		}

		#endregion
	}
}