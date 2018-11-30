using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace HC.POSCloud.ProductTags
{
    /// <summary>
    /// 商品分类
    /// </summary>
    [Table("ProductTags")]
    public class ProductTag : FullAuditedEntity
    {

        /// <summary>
        /// 分类名称
        /// </summary>
        [Required]
        [StringLength(200)]
        public virtual string Name { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Required]
        public virtual int Seq { get; set; }
    }
}
