
using System;
using System.Data;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Abp.UI;
using Abp.AutoMapper;
using Abp.Authorization;
using Abp.Linq.Extensions;
using Abp.Domain.Repositories;
using Abp.Application.Services;
using Abp.Application.Services.Dto;


using HC.POSCloud.Retailers.Dtos;
using HC.POSCloud.Retailers;

namespace HC.POSCloud.Retailers
{
    /// <summary>
    /// Retailer应用层服务的接口方法
    ///</summary>
    public interface IRetailerAppService : IApplicationService
    {
        /// <summary>
		/// 获取Retailer的分页列表信息
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<RetailerListDto>> GetPagedRetailerListAsync(GetRetailersInput input);


		/// <summary>
		/// 通过指定id获取RetailerListDto信息
		/// </summary>
		Task<RetailerListDto> GetRetailerByIdAsync(Guid id);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetRetailerForEditOutput> GetForEdit(NullableIdDto<Guid> input);


        /// <summary>
        /// 添加或者修改Retailer的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<RetailerListDto> CreateOrUpdateRetailerByIdAsync(RetailerEditDto input);


        /// <summary>
        /// 删除Retailer信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteRetailerByIdAsync(Guid id);
    }
}
