
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

namespace HC.POSCloud.Products
{
    /// <summary>
    /// Product应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize(AppPermissions.Pages)]
    public class ProductAppService : POSCloudAppServiceBase, IProductAppService
    {
        private readonly IRepository<Product, Guid> _entityRepository;

        private readonly IProductManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public ProductAppService(
        IRepository<Product, Guid> entityRepository
        ,IProductManager entityManager
        )
        {
            _entityRepository = entityRepository; 
             _entityManager=entityManager;
        }


        /// <summary>
        /// 获取Product的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		[AbpAuthorize(ProductPermissions.Query)] 
        public async Task<PagedResultDto<ProductListDto>> GetPaged(GetProductsInput input)
		{

		    var query = _entityRepository.GetAll();
			// TODO:根据传入的参数添加过滤条件
            

			var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			// var entityListDtos = ObjectMapper.Map<List<ProductListDto>>(entityList);
			var entityListDtos =entityList.MapTo<List<ProductListDto>>();

			return new PagedResultDto<ProductListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取ProductListDto信息
		/// </summary>
		[AbpAuthorize(ProductPermissions.Query)] 
		public async Task<ProductListDto> GetById(EntityDto<Guid> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<ProductListDto>();
		}

		/// <summary>
		/// 获取编辑 Product
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(ProductPermissions.Create,ProductPermissions.Edit)]
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
		[AbpAuthorize(ProductPermissions.Create,ProductPermissions.Edit)]
		public async Task CreateOrUpdate(CreateOrUpdateProductInput input)
		{

			if (input.Product.Id.HasValue)
			{
				await Update(input.Product);
			}
			else
			{
				await Create(input.Product);
			}
		}


		/// <summary>
		/// 新增Product
		/// </summary>
		[AbpAuthorize(ProductPermissions.Create)]
		protected virtual async Task<ProductEditDto> Create(ProductEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <Product>(input);
            var entity=input.MapTo<Product>();
			

			entity = await _entityRepository.InsertAsync(entity);
			return entity.MapTo<ProductEditDto>();
		}

		/// <summary>
		/// 编辑Product
		/// </summary>
		[AbpAuthorize(ProductPermissions.Edit)]
		protected virtual async Task Update(ProductEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

			var entity = await _entityRepository.GetAsync(input.Id.Value);
			input.MapTo(entity);

			// ObjectMapper.Map(input, entity);
		    await _entityRepository.UpdateAsync(entity);
		}



		/// <summary>
		/// 删除Product信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(ProductPermissions.Delete)]
		public async Task Delete(EntityDto<Guid> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
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
		/// 导出Product为excel表,等待开发。
		/// </summary>
		/// <returns></returns>
		//public async Task<FileDto> GetToExcel()
		//{
		//	var users = await UserManager.Users.ToListAsync();
		//	var userListDtos = ObjectMapper.Map<List<UserListDto>>(users);
		//	await FillRoleNames(userListDtos);
		//	return _userListExcelExporter.ExportToFile(userListDtos);
		//}

    }
}


