using System.Threading.Tasks;
using Abp.Application.Services;
using HC.POSCloud.Sessions.Dto;

namespace HC.POSCloud.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
