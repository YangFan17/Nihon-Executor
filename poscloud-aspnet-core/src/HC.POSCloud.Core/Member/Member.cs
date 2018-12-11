using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using HC.POSCloud.PosEnmus;

namespace HC.POSCloud.Members
{
    /// <summary>
    /// 会员表
    /// </summary>
    [Table("Members")]
    public class Member : Entity<Guid>, IHasCreationTime
    {

        /// <summary>
        /// 手机号（会员标识）
        /// </summary>
        [Required]
        [StringLength(20)]
        public virtual string Phone { get; set; }

        /// <summary>
        /// 微信昵称
        /// </summary>
        [StringLength(50)]
        public virtual string NickName { get; set; }

        /// <summary>
        /// 微信OpenId
        /// </summary>
        [StringLength(50)]
        public virtual string OpenId { get; set; }

        /// <summary>
        /// 微信头像
        /// </summary>
        [StringLength(500)]
        public virtual string HeadImgUrl { get; set; }

        /// <summary>
        /// 用户类型(会员)
        /// </summary>
        public virtual int? UserType { get; set; }

        /// <summary>
        /// 绑定状态(枚举 已绑定、未绑定)
        /// </summary>
        public virtual int? BindStatus { get; set; }

        /// <summary>
        /// 绑定时间
        /// </summary>
        public virtual DateTime? BindTime { get; set; }

        /// <summary>
        /// 解绑时间
        /// </summary>
        public virtual DateTime? UnBindTime { get; set; }

        /// <summary>
        /// 会员总积分
        /// </summary>
        public virtual int? Integral { get; set; }

        /// <summary>
        /// CreationTime
        /// </summary>
        public virtual DateTime CreationTime { get; set; }
    }
}
