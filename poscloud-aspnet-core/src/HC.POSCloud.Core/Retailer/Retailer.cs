using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using HC.POSCloud.PosEnmus;
namespace HC.POSCloud.Retailers
{
    /// <summary>
    /// 零售客户
    /// </summary>
    [Table("Retailers")]
    public class Retailer : FullAuditedEntity<Guid>
    {

        /// <summary>
        /// 客户编码
        /// </summary>
        [Required]
        [StringLength(50)]
        public virtual string Code { get; set; }

        /// <summary>
        /// 客户姓名
        /// </summary>
        [Required]
        [StringLength(50)]
        public virtual string Name { get; set; }

        /// <summary>
        /// 许可证号
        /// </summary>
        [Required]
        [StringLength(50)]
        public virtual string LicenseKey { get; set; }

        /// <summary>
        /// 经营地址
        /// </summary>
        [StringLength(50)]
        public virtual string BusinessAddress { get; set; }

        /// <summary>
        /// 客户分档
        /// </summary>
        [StringLength(100)]
        public virtual string ArchivalLevel { get; set; }

        /// <summary>
        /// 订货周期
        /// </summary>
        [StringLength(100)]
        public virtual string OrderCycle { get; set; }

        /// <summary>
        /// 订货电话
        /// </summary>
        [StringLength(100)]
        public virtual string Telephone { get; set; }

        /// <summary>
        /// 客户状态
        /// </summary>
        [Required]
        public virtual bool IsAction { get; set; }

        /// <summary>
        /// 分公司 快照
        /// </summary>
        [StringLength(200)]
        public virtual string BranchCompany { get; set; }

        /// <summary>
        /// 市场部﻿ 快照
        /// </summary>
        [StringLength(100)]
        public virtual string Department { get; set; }

        /// <summary>
        /// 营销经理ID
        /// </summary>
        [StringLength(50)]
        public virtual string SlsmanId { get; set; }

        /// <summary>
        /// 营销经理名称
        /// </summary>
        [StringLength(50)]
        public virtual string SlsmanName { get; set; }

        /// <summary>
        /// 所在区域
        /// </summary>
        [StringLength(100)]
        public virtual string Area { get; set; }

        /// <summary>
        /// 订货方式(枚举 无、网上订货、电话订货、手机)
        /// </summary>
        public virtual int? OrderMode { get; set; }

        /// <summary>
        /// 终端类型(枚举 无、建议终端、普通终端、现代终端)
        /// </summary>
        public virtual int? TerminalType { get; set; }

        /// <summary>
        /// 商圈类型
        /// </summary>
        [StringLength(100)]
        public virtual string BusinessType { get; set; }

        /// <summary>
        /// 终端授权码
        /// </summary>
        [StringLength(100)]
        public virtual string AuthorizationCode { get; set; }
    }
}
