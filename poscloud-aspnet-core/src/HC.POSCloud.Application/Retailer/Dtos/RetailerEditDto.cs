
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using HC.POSCloud.Retailers;

namespace  HC.POSCloud.Retailers.Dtos
{
    public class RetailerEditDto : FullAuditedEntityDto<Guid>
    {

        /// <summary>
        /// Id
        /// </summary>
        public new Guid? Id { get; set; }         


        
		/// <summary>
		/// Code
		/// </summary>
		[Required(ErrorMessage="Code不能为空")]
		public string Code { get; set; }



		/// <summary>
		/// Name
		/// </summary>
		[Required(ErrorMessage="Name不能为空")]
		public string Name { get; set; }



		/// <summary>
		/// LicenseKey
		/// </summary>
		[Required(ErrorMessage="LicenseKey不能为空")]
		public string LicenseKey { get; set; }



		/// <summary>
		/// BusinessAddress
		/// </summary>
		public string BusinessAddress { get; set; }



		/// <summary>
		/// ArchivalLevel
		/// </summary>
		public string ArchivalLevel { get; set; }



		/// <summary>
		/// OrderCycle
		/// </summary>
		public string OrderCycle { get; set; }



		/// <summary>
		/// Telephone
		/// </summary>
		public string Telephone { get; set; }



		/// <summary>
		/// IsAction
		/// </summary>
		[Required(ErrorMessage="IsAction不能为空")]
		public bool IsAction { get; set; }



		/// <summary>
		/// BranchCompany
		/// </summary>
		public string BranchCompany { get; set; }



		/// <summary>
		/// Department
		/// </summary>
		public string Department { get; set; }



		/// <summary>
		/// SlsmanId
		/// </summary>
		public string SlsmanId { get; set; }



		/// <summary>
		/// SlsmanName
		/// </summary>
		public string SlsmanName { get; set; }



		/// <summary>
		/// Area
		/// </summary>
		public string Area { get; set; }



		/// <summary>
		/// OrderMode
		/// </summary>
		public int? OrderMode { get; set; }



		/// <summary>
		/// TerminalType
		/// </summary>
		public int? TerminalType { get; set; }



		/// <summary>
		/// BusinessType
		/// </summary>
		public string BusinessType { get; set; }



		/// <summary>
		/// AuthorizationCode
		/// </summary>
		public string AuthorizationCode { get; set; }
    }
}