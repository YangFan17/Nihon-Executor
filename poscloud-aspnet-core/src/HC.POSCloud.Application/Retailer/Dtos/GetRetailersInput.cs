
using Abp.Runtime.Validation;
using HC.POSCloud.Dtos;
using HC.POSCloud.Retailers;

namespace HC.POSCloud.Retailers.Dtos
{
    public class GetRetailersInput : PagedSortedAndFilteredInputDto, IShouldNormalize
    {
        private bool isAction;

        public bool IsAction
        {
            get => isAction == true ? true : false;
            set => isAction = value;           
        }
        public string Filter { get; set; }

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
