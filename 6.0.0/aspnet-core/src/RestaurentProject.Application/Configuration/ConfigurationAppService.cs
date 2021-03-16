using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using RestaurentProject.Configuration.Dto;

namespace RestaurentProject.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : RestaurentProjectAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
