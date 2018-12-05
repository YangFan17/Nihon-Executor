
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
    //[AbpAuthorize(AppPermissions.Pages)]
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
		public async Task<ProductTagListDto> GetProductTagByIdAsync(int id)
		{
			var entity = await _entityRepository.GetAsync(id);
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
		/// 新增ProductTag
		/// </summary>
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
        /// 获取商品类型
        /// </summary>
        /// <returns></returns>
        public async Task<List<TagsNzTreeNode>> GetTagTreesAsync()
        {
            var Tags = await _entityRepository.GetAll().OrderBy(v => v.Seq).AsNoTracking()
             .Select(v => new ProductTagListDto() { Id = v.Id, Name = v.Name }).ToListAsync();
            List<TagsNzTreeNode> list = new List<TagsNzTreeNode>();
            TagsNzTreeNode treeNodeRoot = new TagsNzTreeNode();
            treeNodeRoot.title = "全部";
            treeNodeRoot.key = "root";
            treeNodeRoot.Expanded = true;
            treeNodeRoot.children = new List<NzTreeNode>();
            if (Tags.Count > 0)
            {
                foreach (var item in Tags)
                {
                    NzTreeNode treeNode = new NzTreeNode()
                    {
                        key = item.Id.ToString(),
                        title = item.Name.ToString(),
                        IsLeaf = true,
                    };
                    treeNodeRoot.children.Add(treeNode);
                }
            }
            list.Add(treeNodeRoot);
            return list;
        }

        /// <summary>
        /// 创建商品分类
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ProductTagEditDto> CreateProductTagAsync(ProductTagEditDto input)
        {
            var entity = input.MapTo<ProductTag>();
            entity = await _entityRepository.InsertAsync(entity);
            return entity.MapTo<ProductTagEditDto>();
        }

        /// <summary>
        /// 修改商品分类
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ProductTagEditDto> EditProductTagAsync(ProductTagEditDto input)
        {
            var entity = await _entityRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);
            await _entityRepository.UpdateAsync(entity);
            return entity.MapTo<ProductTagEditDto>();
        }

        /// <summary>
        /// 获取商品类型Select
        /// </summary>
        /// <returns></returns>
        public async Task<List<SelectGroup>> GetProductTagsSelectGroup()
        {
            var entity = await (from pt in _entityRepository.GetAll()
                                select new
                                {
                                    text = pt.Name,
                                    value = pt.Id,
                                    seq = pt.Seq
                                }).OrderBy(v => v.seq).AsNoTracking().ToListAsync();
            return entity.MapTo<List<SelectGroup>>();
        }
    }
}


