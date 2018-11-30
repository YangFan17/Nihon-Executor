
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


using HC.POSCloud.ProductTags;
using HC.POSCloud.ProductTags.Dtos;
using HC.POSCloud.ProductTags.DomainService;
using HC.POSCloud.ProductTags.Authorization;
using HC.POSCloud.Authorization;

namespace HC.POSCloud.ProductTags
{
    /// <summary>
    /// ProductTag应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize(AppPermissions.Pages)]
    public class ProductTagAppService : POSCloudAppServiceBase, IProductTagAppService
    {
        private readonly IRepository<ProductTag, int> _entityRepository;

        private readonly IProductTagManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public ProductTagAppService(
        IRepository<ProductTag, int> entityRepository
        ,IProductTagManager entityManager
        )
        {
            _entityRepository = entityRepository; 
             _entityManager=entityManager;
        }


        /// <summary>
        /// 获取ProductTag的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		[AbpAuthorize(ProductTagPermissions.Query)] 
        public async Task<PagedResultDto<ProductTagListDto>> GetPaged(GetProductTagsInput input)
		{

		    var query = _entityRepository.GetAll();
			// TODO:根据传入的参数添加过滤条件
            

			var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			// var entityListDtos = ObjectMapper.Map<List<ProductTagListDto>>(entityList);
			var entityListDtos =entityList.MapTo<List<ProductTagListDto>>();

			return new PagedResultDto<ProductTagListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取ProductTagListDto信息
		/// </summary>
		[AbpAuthorize(ProductTagPermissions.Query)] 
		public async Task<ProductTagListDto> GetById(EntityDto<int> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<ProductTagListDto>();
		}

		/// <summary>
		/// 获取编辑 ProductTag
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(ProductTagPermissions.Create,ProductTagPermissions.Edit)]
		public async Task<GetProductTagForEditOutput> GetForEdit(NullableIdDto<int> input)
		{
			var output = new GetProductTagForEditOutput();
ProductTagEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<ProductTagEditDto>();

				//productTagEditDto = ObjectMapper.Map<List<productTagEditDto>>(entity);
			}
			else
			{
				editDto = new ProductTagEditDto();
			}

			output.ProductTag = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改ProductTag的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(ProductTagPermissions.Create,ProductTagPermissions.Edit)]
		public async Task CreateOrUpdate(CreateOrUpdateProductTagInput input)
		{

			if (input.ProductTag.Id.HasValue)
			{
				await Update(input.ProductTag);
			}
			else
			{
				await Create(input.ProductTag);
			}
		}


		/// <summary>
		/// 新增ProductTag
		/// </summary>
		[AbpAuthorize(ProductTagPermissions.Create)]
		protected virtual async Task<ProductTagEditDto> Create(ProductTagEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <ProductTag>(input);
            var entity=input.MapTo<ProductTag>();
			

			entity = await _entityRepository.InsertAsync(entity);
			return entity.MapTo<ProductTagEditDto>();
		}

		/// <summary>
		/// 编辑ProductTag
		/// </summary>
		[AbpAuthorize(ProductTagPermissions.Edit)]
		protected virtual async Task Update(ProductTagEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

			var entity = await _entityRepository.GetAsync(input.Id.Value);
			input.MapTo(entity);

			// ObjectMapper.Map(input, entity);
		    await _entityRepository.UpdateAsync(entity);
		}



		/// <summary>
		/// 删除ProductTag信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(ProductTagPermissions.Delete)]
		public async Task Delete(EntityDto<int> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除ProductTag的方法
		/// </summary>
		[AbpAuthorize(ProductTagPermissions.BatchDelete)]
		public async Task BatchDelete(List<int> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}


		/// <summary>
		/// 导出ProductTag为excel表,等待开发。
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


