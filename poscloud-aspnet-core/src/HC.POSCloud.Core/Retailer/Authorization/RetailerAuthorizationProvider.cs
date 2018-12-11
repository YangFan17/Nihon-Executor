

using System.Linq;
using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.MultiTenancy;
using HC.POSCloud.Authorization;

namespace HC.POSCloud.Retailers.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="RetailerPermissions" /> for all permission names. Retailer
    ///</summary>
    public class RetailerAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public RetailerAuthorizationProvider()
		{

		}

        public RetailerAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public RetailerAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了Retailer 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var entityPermission = administration.CreateChildPermission(RetailerPermissions.Node , L("Retailer"));
			entityPermission.CreateChildPermission(RetailerPermissions.Query, L("QueryRetailer"));
			entityPermission.CreateChildPermission(RetailerPermissions.Create, L("CreateRetailer"));
			entityPermission.CreateChildPermission(RetailerPermissions.Edit, L("EditRetailer"));
			entityPermission.CreateChildPermission(RetailerPermissions.Delete, L("DeleteRetailer"));
			entityPermission.CreateChildPermission(RetailerPermissions.BatchDelete, L("BatchDeleteRetailer"));
			entityPermission.CreateChildPermission(RetailerPermissions.ExportExcel, L("ExportExcelRetailer"));


		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, POSCloudConsts.LocalizationSourceName);
		}
    }
}