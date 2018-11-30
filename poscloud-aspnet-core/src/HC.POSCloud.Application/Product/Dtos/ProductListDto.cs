

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using HC.POSCloud.Products;

namespace HC.POSCloud.Products.Dtos
{
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
    }
}