

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HC.POSCloud.Members;

namespace HC.POSCloud.Members.Dtos
{
    public class CreateOrUpdateMemberInput
    {
        [Required]
        public MemberEditDto Member { get; set; }

    }
}