

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HC.POSCloud.Products;

namespace HC.POSCloud.Products.Dtos
{
    public class CreateOrUpdateProductInput
    {
        [Required]
        public ProductEditDto Product { get; set; }

    }
}