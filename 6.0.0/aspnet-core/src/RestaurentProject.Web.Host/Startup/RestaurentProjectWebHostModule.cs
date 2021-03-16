using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using RestaurentProject.Configuration;

namespace RestaurentProject.Web.Host.Startup
{
    [DependsOn(
       typeof(RestaurentProjectWebCoreModule))]
    public class RestaurentProjectWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public RestaurentProjectWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(RestaurentProjectWebHostModule).GetAssembly());
        }
    }
}
