

using System.Linq;
using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.MultiTenancy;
using HC.POSCloud.Authorization;

namespace HC.POSCloud.Members.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="MemberPermissions" /> for all permission names. Member
    ///</summary>
    public class MemberAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public MemberAuthorizationProvider()
		{

		}

        public MemberAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public MemberAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了Member 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var entityPermission = administration.CreateChildPermission(MemberPermissions.Node , L("Member"));
			entityPermission.CreateChildPermission(MemberPermissions.Query, L("QueryMember"));
			entityPermission.CreateChildPermission(MemberPermissions.Create, L("CreateMember"));
			entityPermission.CreateChildPermission(MemberPermissions.Edit, L("EditMember"));
			entityPermission.CreateChildPermission(MemberPermissions.Delete, L("DeleteMember"));
			entityPermission.CreateChildPermission(MemberPermissions.BatchDelete, L("BatchDeleteMember"));
			entityPermission.CreateChildPermission(MemberPermissions.ExportExcel, L("ExportExcelMember"));


		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, POSCloudConsts.LocalizationSourceName);
		}
    }
}