

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HC.POSCloud.ProductTags;

namespace HC.POSCloud.ProductTags.Dtos
{
    public class CreateOrUpdateProductTagInput
    {
        [Required]
        public ProductTagEditDto ProductTag { get; set; }

    }
}