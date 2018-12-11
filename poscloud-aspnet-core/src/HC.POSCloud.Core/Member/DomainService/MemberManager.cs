

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
using HC.POSCloud.Members;


namespace HC.POSCloud.Members.DomainService
{
    /// <summary>
    /// Member领域层的业务管理
    ///</summary>
    public class MemberManager :POSCloudDomainServiceBase, IMemberManager
    {
		
		private readonly IRepository<Member,Guid> _repository;

		/// <summary>
		/// Member的构造方法
		///</summary>
		public MemberManager(
			IRepository<Member, Guid> repository
		)
		{
			_repository =  repository;
		}


		/// <summary>
		/// 初始化
		///</summary>
		public void InitMember()
		{
			throw new NotImplementedException();
		}

		// TODO:编写领域业务代码



		 
		  
		 

	}
}
