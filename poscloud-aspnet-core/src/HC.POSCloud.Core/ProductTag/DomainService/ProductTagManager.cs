

using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Abp.Linq;
using Abp.Linq.Extensions;
using Abp.Extensions;
using Abp.UI;
using Abp.Domain.Repositories;
using Abp.Domain.Services;

using HC.POSCloud;
using HC.POSCloud.ProductTags;


namespace HC.POSCloud.ProductTags.DomainService
{
    /// <summary>
    /// ProductTag领域层的业务管理
    ///</summary>
    public class ProductTagManager :POSCloudDomainServiceBase, IProductTagManager
    {
		
		private readonly IRepository<ProductTag,int> _repository;

		/// <summary>
		/// ProductTag的构造方法
		///</summary>
		public ProductTagManager(
			IRepository<ProductTag, int> repository
		)
		{
			_repository =  repository;
		}


		/// <summary>
		/// 初始化
		///</summary>
		public void InitProductTag()
		{
			throw new NotImplementedException();
		}

		// TODO:编写领域业务代码



		 
		  
		 

	}
}
