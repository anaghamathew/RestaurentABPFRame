using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using RestaurentProject.Authorization;
using RestaurentProject.Foods;
using RestaurentProject.Foods.Dto;

namespace RestaurentProject
{
    [DependsOn(
        typeof(RestaurentProjectCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class RestaurentProjectApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<RestaurentProjectAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(RestaurentProjectApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
               
                cfg => cfg.AddMaps(thisAssembly));

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }
    }
}
