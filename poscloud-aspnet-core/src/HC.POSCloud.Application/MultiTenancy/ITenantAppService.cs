using Abp.Application.Services;
using Abp.Application.Services.Dto;
using HC.POSCloud.MultiTenancy.Dto;

namespace HC.POSCloud.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
