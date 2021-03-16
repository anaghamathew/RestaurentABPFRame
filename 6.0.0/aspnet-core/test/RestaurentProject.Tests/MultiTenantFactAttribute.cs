using Xunit;

namespace RestaurentProject.Tests
{
    public sealed class MultiTenantFactAttribute : FactAttribute
    {
        public MultiTenantFactAttribute()
        {
            if (!RestaurentProjectConsts.MultiTenancyEnabled)
            {
                Skip = "MultiTenancy is disabled.";
            }
        }
    }
}
