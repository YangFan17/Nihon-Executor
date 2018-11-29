using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using HC.POSCloud.Configuration.Dto;

namespace HC.POSCloud.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : POSCloudAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
