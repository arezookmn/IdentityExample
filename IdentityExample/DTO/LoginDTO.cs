using System.ComponentModel.DataAnnotations;

namespace IdentityExample.DTO
{
    public class LoginDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "The {0} must be at least {1} characters long.")]
        public string Password { get; set; }


    }
}
