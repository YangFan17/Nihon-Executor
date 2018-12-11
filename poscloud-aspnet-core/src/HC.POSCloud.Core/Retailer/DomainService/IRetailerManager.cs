

using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using HC.POSCloud.Retailers;


namespace HC.POSCloud.Retailers.DomainService
{
    public interface IRetailerManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        ///</summary>
        void InitRetailer();



		 
      
         

    }
}
