using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using RestaurentProject.EntityFrameworkCore;
using RestaurentProject.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace RestaurentProject.Web.Tests
{
    [DependsOn(
        typeof(RestaurentProjectWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class RestaurentProjectWebTestModule : AbpModule
    {
        public RestaurentProjectWebTestModule(RestaurentProjectEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(RestaurentProjectWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(RestaurentProjectWebMvcModule).Assembly);
        }
    }
}