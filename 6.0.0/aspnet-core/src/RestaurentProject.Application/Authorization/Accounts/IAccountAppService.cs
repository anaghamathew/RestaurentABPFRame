using System.Threading.Tasks;
using Abp.Application.Services;
using RestaurentProject.Authorization.Accounts.Dto;

namespace RestaurentProject.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
