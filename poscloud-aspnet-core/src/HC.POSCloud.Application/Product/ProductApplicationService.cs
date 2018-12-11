
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
using Abp.Extensions;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Application.Services.Dto;
using Abp.Linq.Extensions;


using HC.POSCloud.Products;
using HC.POSCloud.Products.Dtos;
using HC.POSCloud.Products.DomainService;
using HC.POSCloud.Products.Authorization;
using HC.POSCloud.Authorization;
using HC.POSCloud.ProductTags;

namespace HC.POSCloud.Products
{
    /// <summary>
    /// Product应用层服务的接口实现方法  
    ///</summary>
    //[AbpAuthorize(AppPermissions.Pages)]
    public class ProductAppService : POSCloudAppServiceBase, IProductAppService
    {
        private readonly IRepository<Product, Guid> _entityRepository;
        private readonly IRepository<ProductTag, int> _productTagRepository;
        private readonly IProductManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public ProductAppService(
        IRepository<Product, Guid> entityRepository
        ,IRepository<ProductTag, int> productTagRepository
        , IProductManager entityManager
        )
        {
            _entityRepository = entityRepository;
            _productTagRepository = productTagRepository;
            _entityManager = entityManager;
        }


        /// <summary>
        /// 获取Product的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<ProductListDto>> GetPagedProductListAsync(GetProductsInput input)
        {
            if (input.NodeKey != "root")
            {
                var query = _entityRepository.GetAll().Where(v => v.ProductTagId == Convert.ToInt32(input.NodeKey))
                                    .WhereIf(!string.IsNullOrEmpty(input.Filter), r => r.Name.Contains(input.Filter) || r.BarCode.Contains(input.Filter));
                var tag = _productTagRepository.GetAll();
                var result = from q in query
                           join t in tag on q.ProductTagId equals t.Id
                           select new ProductListDto() {
                               Id = q.Id,
                               Name = q.Name,
                               Unit =q.Unit,
                               ProductTagId =t.Id,
                               ProductTagName = t.Name,
                               BarCode = q.BarCode,
                               IsEnable = q.IsEnable,                          
                           };
                var count = await result.CountAsync();
                var entityList = await result
                        .OrderBy(input.Sorting).AsNoTracking()
                        .PageBy(input)
                        .ToListAsync();
                var entityListDtos = entityList.MapTo<List<ProductListDto>>();
                return new PagedResultDto<ProductListDto>(count, entityListDtos);
            }
            else
            {
                var query = _entityRepository.GetAll().WhereIf(!string.IsNullOrEmpty(input.Filter), r => r.Name.Contains(input.Filter) || r.BarCode.Contains(input.Filter));
                var tag = _productTagRepository.GetAll();
                var result = from q in query
                             join t in tag on q.ProductTagId equals t.Id
                             select new ProductListDto()
                             {
                                 Id = q.Id,
                                 Name = q.Name,
                                 Unit = q.Unit,
                                 ProductTagName = t.Name,
                                 BarCode = q.BarCode,
                                 IsEnable = q.IsEnable,
                             };
                var count = await result.CountAsync();
                var entityList = await result
                        .OrderBy(input.Sorting).AsNoTracking()
                        .PageBy(input)
                        .ToListAsync();
                var entityListDtos = entityList.MapTo<List<ProductListDto>>();
                return new PagedResultDto<ProductListDto>(count, entityListDtos);
            }
        }


        /// <summary>
        /// 通过指定id获取ProductListDto信息
        /// </summary>
        public async Task<ProductListDto> GetProductByIdAsync(Guid id)
        {
            var entity = await _entityRepository.GetAsync(id);
            return entity.MapTo<ProductListDto>();
        }

        /// <summary>
        /// 获取编辑 Product
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(ProductPermissions.Create, ProductPermissions.Edit)]
        public async Task<GetProductForEditOutput> GetForEdit(NullableIdDto<Guid> input)
        {
            var output = new GetProductForEditOutput();
            ProductEditDto editDto;

            if (input.Id.HasValue)
            {
                var entity = await _entityRepository.GetAsync(input.Id.Value);

                editDto = entity.MapTo<ProductEditDto>();

                //productEditDto = ObjectMapper.Map<List<productEditDto>>(entity);
            }
            else
            {
                editDto = new ProductEditDto();
            }

            output.Product = editDto;
            return output;
        }


        /// <summary>
        /// 添加或者修改Product的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ProductEditDto> CreateOrUpdateProductAsync(ProductEditDto input)
        {

            if (input.Id.HasValue)
            {
                return await Update(input);
            }
            else
            {
                return await Create(input);
            }
        }


        /// <summary>
        /// 新增Product
        /// </summary>
        protected virtual async Task<ProductEditDto> Create(ProductEditDto input)
        {
            var entity = input.MapTo<Product>();
            var id = await _entityRepository.InsertAndGetIdAsync(entity);
            return entity.MapTo<ProductEditDto>();
        }

        /// <summary>
        /// 编辑Product
        /// </summary>
        protected virtual async Task<ProductEditDto> Update(ProductEditDto input)
        {
            var entity = await _entityRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);
            await _entityRepository.UpdateAsync(entity);
            return entity.MapTo<ProductEditDto>();
        }



        /// <summary>
        /// 删除Product信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task DeleteProductByIdAsync(Guid id)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _entityRepository.DeleteAsync(id);
        }

        /// <summary>
        /// 批量删除Product的方法
        /// </summary>
        [AbpAuthorize(ProductPermissions.BatchDelete)]
        public async Task BatchDelete(List<Guid> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        /// <summary>
        /// 更新商品标签
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ProductListDto> CreateOrUpdateProductLable(ProductEditDto input)
        {
            var entity = await _entityRepository.GetAsync(input.Id.Value);
            entity.Lable = input.Lable;
            if (string.IsNullOrEmpty(input.Lable))
            {
                entity.Lable = null;
            }
            var result = await _entityRepository.UpdateAsync(entity);
            return result.MapTo<ProductListDto>();
        }
    }
}


