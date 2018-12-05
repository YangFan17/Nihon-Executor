
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


using HC.POSCloud.ProductTags.Dtos;
using HC.POSCloud.ProductTags;

namespace HC.POSCloud.ProductTags
{
    /// <summary>
    /// ProductTag应用层服务的接口方法
    ///</summary>
    public interface IProductTagAppService : IApplicationService
    {
        /// <summary>
		/// 获取ProductTag的分页列表信息
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<ProductTagListDto>> GetPaged(GetProductTagsInput input);


		/// <summary>
		/// 通过指定id获取ProductTagListDto信息
		/// </summary>
		Task<ProductTagListDto> GetProductTagByIdAsync(int id);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetProductTagForEditOutput> GetForEdit(NullableIdDto<int> input);


        /// <summary>
        /// 删除ProductTag信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<int> input);


        /// <summary>
        /// 批量删除ProductTag
        /// </summary>
        Task BatchDelete(List<int> input);

        Task<List<TagsNzTreeNode>> GetTagTreesAsync();
        Task<ProductTagEditDto> CreateProductTagAsync(ProductTagEditDto input);
        Task<ProductTagEditDto> EditProductTagAsync(ProductTagEditDto input);
        Task<List<SelectGroup>> GetProductTagsSelectGroup();
    }
}
