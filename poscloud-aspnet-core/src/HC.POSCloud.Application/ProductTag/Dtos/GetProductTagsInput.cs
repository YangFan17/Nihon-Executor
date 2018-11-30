
using Abp.Runtime.Validation;
using HC.POSCloud.Dtos;
using HC.POSCloud.ProductTags;

namespace HC.POSCloud.ProductTags.Dtos
{
    public class GetProductTagsInput : PagedSortedAndFilteredInputDto, IShouldNormalize
    {

        /// <summary>
        /// 正常化排序使用
        /// </summary>
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }

    }
}
