using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using HC.POSCloud.MultiTenancy;

namespace HC.POSCloud.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
