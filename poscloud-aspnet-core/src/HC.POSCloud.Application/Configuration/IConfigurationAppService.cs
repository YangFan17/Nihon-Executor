using System.Threading.Tasks;
using HC.POSCloud.Configuration.Dto;

namespace HC.POSCloud.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
