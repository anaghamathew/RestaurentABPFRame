using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using RestaurentProject.Authorization.Roles;
using RestaurentProject.Authorization.Users;
using RestaurentProject.MultiTenancy;
using Microsoft.Extensions.Logging;

namespace RestaurentProject.Identity
{
    public class SecurityStampValidator : AbpSecurityStampValidator<Tenant, Role, User>
    {
        public SecurityStampValidator(
            IOptions<SecurityStampValidatorOptions> options,
            SignInManager signInManager,
            ISystemClock systemClock,
            ILoggerFactory loggerFactory) 
            : base(options, signInManager, systemClock, loggerFactory)
        {
        }
    }
}
