using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace HC.POSCloud.Controllers
{
    public abstract class POSCloudControllerBase: AbpController
    {
        protected POSCloudControllerBase()
        {
            LocalizationSourceName = POSCloudConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
