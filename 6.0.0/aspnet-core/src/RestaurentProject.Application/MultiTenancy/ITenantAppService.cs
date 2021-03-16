using Abp.Application.Services;
using RestaurentProject.MultiTenancy.Dto;

namespace RestaurentProject.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

