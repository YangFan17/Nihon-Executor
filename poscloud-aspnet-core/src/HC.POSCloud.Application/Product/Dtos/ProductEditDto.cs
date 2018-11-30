
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using HC.POSCloud.Products;

namespace  HC.POSCloud.Products.Dtos
{
    public class ProductEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public Guid? Id { get; set; }         


        
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