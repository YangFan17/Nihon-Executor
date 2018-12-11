

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
using HC.POSCloud.Retailers;


namespace HC.POSCloud.Retailers.DomainService
{
    /// <summary>
    /// Retailer领域层的业务管理
    ///</summary>
    public class RetailerManager :POSCloudDomainServiceBase, IRetailerManager
    {
		
		private readonly IRepository<Retailer,Guid> _repository;

		/// <summary>
		/// Retailer的构造方法
		///</summary>
		public RetailerManager(
			IRepository<Retailer, Guid> repository
		)
		{
			_repository =  repository;
		}


		/// <summary>
		/// 初始化
		///</summary>
		public void InitRetailer()
		{
			throw new NotImplementedException();
		}

		// TODO:编写领域业务代码



		 
		  
		 

	}
}
