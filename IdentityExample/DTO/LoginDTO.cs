using System.ComponentModel.DataAnnotations;

namespace IdentityExample.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Email cant be blank")]
        [EmailAddress(ErrorMessage = "Your email not in correct format")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password cant be blank")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "The {0} must be at least {1} characters long.")]
        public string Password { get; set; }


    }
}
