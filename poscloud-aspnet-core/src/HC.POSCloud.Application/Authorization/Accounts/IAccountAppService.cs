using System.Threading.Tasks;
using Abp.Application.Services;
using HC.POSCloud.Authorization.Accounts.Dto;

namespace HC.POSCloud.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
