using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using RestaurentProject.EntityFrameworkCore.Seed;

namespace RestaurentProject.EntityFrameworkCore
{
    [DependsOn(
        typeof(RestaurentProjectCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class RestaurentProjectEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<RestaurentProjectDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        RestaurentProjectDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        RestaurentProjectDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(RestaurentProjectEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
