using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using HC.POSCloud.Authorization;

namespace HC.POSCloud
{
    [DependsOn(
        typeof(POSCloudCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class POSCloudApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<POSCloudAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(POSCloudApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
