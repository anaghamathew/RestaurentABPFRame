using System.Threading.Tasks;
using RestaurentProject.Configuration.Dto;

namespace RestaurentProject.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
