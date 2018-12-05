
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using HC.POSCloud.ProductTags;

namespace  HC.POSCloud.ProductTags.Dtos
{
    public class ProductTagEditDto : FullAuditedEntityDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public new int? Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required(ErrorMessage="Name不能为空")]
		public string Name { get; set; }



		/// <summary>
		/// Seq
		/// </summary>
		[Required(ErrorMessage="Seq不能为空")]
		public int Seq { get; set; }
    }

    public class SelectGroup
    {
        public string text { get; set; }
        public int value { get; set; }
    }
}