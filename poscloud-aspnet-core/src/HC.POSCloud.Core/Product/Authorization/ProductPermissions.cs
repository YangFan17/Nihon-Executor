

namespace HC.POSCloud.Products.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="ProductAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class ProductPermissions
	{
		/// <summary>
		/// Product权限节点
		///</summary>
		public const string Node = "Pages.Product";

		/// <summary>
		/// Product查询授权
		///</summary>
		public const string Query = "Pages.Product.Query";

		/// <summary>
		/// Product创建权限
		///</summary>
		public const string Create = "Pages.Product.Create";

		/// <summary>
		/// Product修改权限
		///</summary>
		public const string Edit = "Pages.Product.Edit";

		/// <summary>
		/// Product删除权限
		///</summary>
		public const string Delete = "Pages.Product.Delete";

        /// <summary>
		/// Product批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.Product.BatchDelete";

		/// <summary>
		/// Product导出Excel
		///</summary>
		public const string ExportExcel="Pages.Product.ExportExcel";

		 
		 
         
    }

}

