

using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using HC.POSCloud.ProductTags;


namespace HC.POSCloud.ProductTags.DomainService
{
    public interface IProductTagManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        ///</summary>
        void InitProductTag();



		 
      
         

    }
}
