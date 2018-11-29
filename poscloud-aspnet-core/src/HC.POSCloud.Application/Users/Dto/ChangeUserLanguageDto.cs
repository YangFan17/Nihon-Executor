using System.ComponentModel.DataAnnotations;

namespace HC.POSCloud.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}