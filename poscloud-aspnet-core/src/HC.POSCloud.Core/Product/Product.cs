using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace HC.POSCloud.Products
{
    /// <summary>
    /// 商品表
    /// </summary>
    [Table("Products")]
    public class Product : FullAuditedEntity<Guid>
    {

        /// <summary>
        /// 商品名称
        /// </summary>
        [Required]
        [StringLength(200)]
        public virtual string Name { get; set; }

        /// <summary>
        /// 商品图片
        /// </summary>
        [StringLength(500)]
        public virtual string PhotoUrl { get; set; }

        /// <summary>
        /// 产品类型（外键Id：烟、酒、饮料、副食、其它）
        /// </summary>
        [Required]
        public virtual int ProductTagId { get; set; }

        /// <summary>
        /// 销售价
        /// </summary>
        public virtual decimal? RetailPrice { get; set; }

        /// <summary>
        /// 进货价
        /// </summary>
        public virtual decimal? PurchasePrice { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        [StringLength(50)]
        public virtual string Unit { get; set; }

        /// <summary>
        /// 条码
        /// </summary>
        [StringLength(50)]
        public virtual string BarCode { get; set; }

        /// <summary>
        /// 商品描述
        /// </summary>
        [StringLength(500)]
        public virtual string Desc { get; set; }
    }
}
