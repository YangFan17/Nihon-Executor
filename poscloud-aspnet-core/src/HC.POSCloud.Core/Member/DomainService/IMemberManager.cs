

using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using HC.POSCloud.Members;


namespace HC.POSCloud.Members.DomainService
{
    public interface IMemberManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        ///</summary>
        void InitMember();



		 
      
         

    }
}
