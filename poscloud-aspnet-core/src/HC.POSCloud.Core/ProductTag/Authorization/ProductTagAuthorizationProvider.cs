

using System.Linq;
using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.MultiTenancy;
using HC.POSCloud.Authorization;

namespace HC.POSCloud.ProductTags.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="ProductTagPermissions" /> for all permission names. ProductTag
    ///</summary>
    public class ProductTagAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public ProductTagAuthorizationProvider()
		{

		}

        public ProductTagAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public ProductTagAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了ProductTag 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var entityPermission = administration.CreateChildPermission(ProductTagPermissions.Node , L("ProductTag"));
			entityPermission.CreateChildPermission(ProductTagPermissions.Query, L("QueryProductTag"));
			entityPermission.CreateChildPermission(ProductTagPermissions.Create, L("CreateProductTag"));
			entityPermission.CreateChildPermission(ProductTagPermissions.Edit, L("EditProductTag"));
			entityPermission.CreateChildPermission(ProductTagPermissions.Delete, L("DeleteProductTag"));
			entityPermission.CreateChildPermission(ProductTagPermissions.BatchDelete, L("BatchDeleteProductTag"));
			entityPermission.CreateChildPermission(ProductTagPermissions.ExportExcel, L("ExportExcelProductTag"));


		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, POSCloudConsts.LocalizationSourceName);
		}
    }
}