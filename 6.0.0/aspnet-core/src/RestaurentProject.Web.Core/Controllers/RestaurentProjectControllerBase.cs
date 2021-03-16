using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace RestaurentProject.Controllers
{
    public abstract class RestaurentProjectControllerBase: AbpController
    {
        protected RestaurentProjectControllerBase()
        {
            LocalizationSourceName = RestaurentProjectConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
