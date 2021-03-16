using Abp.Application.Services.Dto;

namespace RestaurentProject.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

