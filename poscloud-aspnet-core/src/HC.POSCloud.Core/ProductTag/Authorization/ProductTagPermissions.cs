

namespace HC.POSCloud.ProductTags.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="ProductTagAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class ProductTagPermissions
	{
		/// <summary>
		/// ProductTag权限节点
		///</summary>
		public const string Node = "Pages.ProductTag";

		/// <summary>
		/// ProductTag查询授权
		///</summary>
		public const string Query = "Pages.ProductTag.Query";

		/// <summary>
		/// ProductTag创建权限
		///</summary>
		public const string Create = "Pages.ProductTag.Create";

		/// <summary>
		/// ProductTag修改权限
		///</summary>
		public const string Edit = "Pages.ProductTag.Edit";

		/// <summary>
		/// ProductTag删除权限
		///</summary>
		public const string Delete = "Pages.ProductTag.Delete";

        /// <summary>
		/// ProductTag批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.ProductTag.BatchDelete";

		/// <summary>
		/// ProductTag导出Excel
		///</summary>
		public const string ExportExcel="Pages.ProductTag.ExportExcel";

		 
		 
         
    }

}

