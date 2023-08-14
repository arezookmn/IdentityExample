using IdentityExample.Enums;
using System.ComponentModel.DataAnnotations;

namespace IdentityExample.DTO
{
    public class RegisterDTO
    {

        [Required(ErrorMessage = "Name cant be blank")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string FullName { get; set; }

        [Required(ErrorMessage ="Email cant be blank")]
        [EmailAddress(ErrorMessage = "Your email not in correct format")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Phone can't be blank")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone number should contain numbers only")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password cant be blank")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "The {0} must be at least {1} characters long.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password cant be blank")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public UserTypeOptions UserType { get; set; } = UserTypeOptions.Customer;

    }
}
