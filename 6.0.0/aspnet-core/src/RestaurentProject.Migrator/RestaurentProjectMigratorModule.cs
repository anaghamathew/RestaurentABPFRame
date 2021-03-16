using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using RestaurentProject.Configuration;
using RestaurentProject.EntityFrameworkCore;
using RestaurentProject.Migrator.DependencyInjection;

namespace RestaurentProject.Migrator
{
    [DependsOn(typeof(RestaurentProjectEntityFrameworkModule))]
    public class RestaurentProjectMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public RestaurentProjectMigratorModule(RestaurentProjectEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(RestaurentProjectMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                RestaurentProjectConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(RestaurentProjectMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
