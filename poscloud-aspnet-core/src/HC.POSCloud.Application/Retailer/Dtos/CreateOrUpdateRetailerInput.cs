

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HC.POSCloud.Retailers;

namespace HC.POSCloud.Retailers.Dtos
{
    public class CreateOrUpdateRetailerInput
    {
        [Required]
        public RetailerEditDto Retailer { get; set; }

    }
}