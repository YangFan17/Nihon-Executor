

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using HC.POSCloud.ProductTags;
using System.Collections.Generic;

namespace HC.POSCloud.ProductTags.Dtos
{
    public class ProductTagListDto : FullAuditedEntityDto 
    {

        
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

    public class NzTreeNode
    {
        public virtual string title { get; set; }
        public virtual string key { get; set; }
        public virtual bool IsLeaf { get; set; }
        public virtual bool Expanded { get; set; }    
        public virtual List<NzTreeNode> children { get; set; }
    }

    public class TagsNzTreeNode : NzTreeNode
    {
        public new List<NzTreeNode> children { get; set; }
    }
}