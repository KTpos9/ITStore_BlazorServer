using System.ComponentModel.DataAnnotations;

namespace Web_Project.Models
{
    public class MemberRegisterModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage ="Password doesn't match, please try again")]
        public string ConfirmPassword { get; set; }
    }
}
