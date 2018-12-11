
using Abp.Runtime.Validation;
using HC.POSCloud.Dtos;
using HC.POSCloud.Members;

namespace HC.POSCloud.Members.Dtos
{
    public class GetMembersInput : PagedSortedAndFilteredInputDto, IShouldNormalize
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
