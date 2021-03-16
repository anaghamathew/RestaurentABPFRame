using System.Threading.Tasks;
using Abp.Application.Services;
using RestaurentProject.Sessions.Dto;

namespace RestaurentProject.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
