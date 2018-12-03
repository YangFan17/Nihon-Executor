
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


using HC.POSCloud.Products.Dtos;
using HC.POSCloud.Products;

namespace HC.POSCloud.Products
{
    /// <summary>
    /// Product应用层服务的接口方法
    ///</summary>
    public interface IProductAppService : IApplicationService
    {
        /// <summary>
		/// 获取Product的分页列表信息
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<ProductListDto>> GetPagedProductListAsync(GetProductsInput input);


		/// <summary>
		/// 通过指定id获取ProductListDto信息
		/// </summary>
		Task<ProductListDto> GetProductByIdAsync(Guid id);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetProductForEditOutput> GetForEdit(NullableIdDto<Guid> input);


        /// <summary>
        /// 添加或者修改Product的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdateProductInput input);


        /// <summary>
        /// 删除Product信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<Guid> input);


        /// <summary>
        /// 批量删除Product
        /// </summary>
        Task BatchDelete(List<Guid> input);


		/// <summary>
        /// 导出Product为excel表
        /// </summary>
        /// <returns></returns>
		//Task<FileDto> GetToExcel();

    }
}
