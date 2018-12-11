

namespace HC.POSCloud.Members.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="MemberAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class MemberPermissions
	{
		/// <summary>
		/// Member权限节点
		///</summary>
		public const string Node = "Pages.Member";

		/// <summary>
		/// Member查询授权
		///</summary>
		public const string Query = "Pages.Member.Query";

		/// <summary>
		/// Member创建权限
		///</summary>
		public const string Create = "Pages.Member.Create";

		/// <summary>
		/// Member修改权限
		///</summary>
		public const string Edit = "Pages.Member.Edit";

		/// <summary>
		/// Member删除权限
		///</summary>
		public const string Delete = "Pages.Member.Delete";

        /// <summary>
		/// Member批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.Member.BatchDelete";

		/// <summary>
		/// Member导出Excel
		///</summary>
		public const string ExportExcel="Pages.Member.ExportExcel";

		 
		 
         
    }

}

