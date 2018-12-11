
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


using HC.POSCloud.Retailers;
using HC.POSCloud.Retailers.Dtos;
using HC.POSCloud.Retailers.DomainService;
using HC.POSCloud.Retailers.Authorization;


namespace HC.POSCloud.Retailers
{
    /// <summary>
    /// Retailer应用层服务的接口实现方法  
    ///</summary>
    //[AbpAuthorize]
    public class RetailerAppService : POSCloudAppServiceBase, IRetailerAppService
    {
        private readonly IRepository<Retailer, Guid> _entityRepository;

        private readonly IRetailerManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public RetailerAppService(
        IRepository<Retailer, Guid> entityRepository
        ,IRetailerManager entityManager
        )
        {
            _entityRepository = entityRepository; 
             _entityManager=entityManager;
        }


        /// <summary>
        /// 获取Retailer的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<RetailerListDto>> GetPagedRetailerListAsync(GetRetailersInput input)
		{
            var query = _entityRepository.GetAll().Where(r => r.IsAction == input.IsAction)
                .WhereIf(!string.IsNullOrEmpty(input.Filter), r => r.Name.Contains(input.Filter) || r.Code.Contains(input.Filter));    
            var count = await query.CountAsync();
			var entityList = await query
					.OrderBy(v=>v.Id).AsNoTracking()
					.PageBy(input)
					.ToListAsync();
			var entityListDtos =entityList.MapTo<List<RetailerListDto>>();
			return new PagedResultDto<RetailerListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取RetailerListDto信息
		/// </summary>
		public async Task<RetailerListDto> GetRetailerByIdAsync(Guid id)
		{
			var entity = await _entityRepository.GetAsync(id);
		    return entity.MapTo<RetailerListDto>();
		}

		/// <summary>
		/// 获取编辑 Retailer
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(RetailerPermissions.Create,RetailerPermissions.Edit)]
		public async Task<GetRetailerForEditOutput> GetForEdit(NullableIdDto<Guid> input)
		{
			var output = new GetRetailerForEditOutput();
            RetailerEditDto editDto;
			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<RetailerEditDto>();

				//retailerEditDto = ObjectMapper.Map<List<retailerEditDto>>(entity);
			}
			else
			{
				editDto = new RetailerEditDto();
			}

			output.Retailer = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改Retailer的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public async Task<RetailerListDto> CreateOrUpdateRetailerByIdAsync(RetailerEditDto input)
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
		/// 新增Retailer
		/// </summary>
		protected virtual async Task<RetailerListDto> Create(RetailerEditDto input)
		{
            var entity=input.MapTo<Retailer>();	
			var id = await _entityRepository.InsertAndGetIdAsync(entity);
			return entity.MapTo<RetailerListDto>();
		}

		/// <summary>
		/// 编辑Retailer
		/// </summary>
		protected virtual async Task<RetailerListDto> Update(RetailerEditDto input)
		{
			var entity = await _entityRepository.GetAsync(input.Id.Value);
			input.MapTo(entity);
		    var result = await _entityRepository.UpdateAsync(entity);
            return result.MapTo<RetailerListDto>();
        }


        /// <summary>
        /// 删除Retailer信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task DeleteRetailerByIdAsync(Guid id)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(id);
		}
    }
}


