

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using HC.POSCloud.Products;
using HC.POSCloud.PosEnmus;
using Abp.AutoMapper;

namespace HC.POSCloud.Products.Dtos
{
    [AutoMapFrom(typeof(Product))]
    public class ProductListDto : FullAuditedEntityDto<Guid> 
    {
		/// <summary>
		/// Name
		/// </summary>
		[Required(ErrorMessage="Name不能为空")]
		public string Name { get; set; }



		/// <summary>
		/// PhotoUrl
		/// </summary>
		public string PhotoUrl { get; set; }



		/// <summary>
		/// ProductTagId
		/// </summary>
		[Required(ErrorMessage="ProductTagId不能为空")]
		public int ProductTagId { get; set; }

        public string ProductTagName { get; set; }

        /// <summary>
        /// RetailPrice
        /// </summary>
        public decimal? RetailPrice { get; set; }



		/// <summary>
		/// PurchasePrice
		/// </summary>
		public decimal? PurchasePrice { get; set; }



		/// <summary>
		/// Unit
		/// </summary>
		public string Unit { get; set; }



		/// <summary>
		/// BarCode
		/// </summary>
		public string BarCode { get; set; }



		/// <summary>
		/// Desc
		/// </summary>
		public string Desc { get; set; }

        /// <summary>
        /// 拼音码
        /// </summary>
        public string PinYinCode { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        [Required(ErrorMessage = "IsEnable不能为空")]
        public EnableEnum IsEnable { get; set; }

        /// <summary>
        /// 商品标签
        /// </summary>
        public string Lable { get; set; }

        /// <summary>
        /// 卷烟等级
        /// </summary>
        public CigaretteGradeEnum? Grade { get; set; }
    }
}