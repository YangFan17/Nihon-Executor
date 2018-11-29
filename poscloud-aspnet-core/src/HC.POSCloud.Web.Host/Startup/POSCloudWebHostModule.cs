using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using HC.POSCloud.Configuration;

namespace HC.POSCloud.Web.Host.Startup
{
    [DependsOn(
       typeof(POSCloudWebCoreModule))]
    public class POSCloudWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public POSCloudWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(POSCloudWebHostModule).GetAssembly());
        }
    }
}
