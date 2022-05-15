using System.ComponentModel.DataAnnotations;

namespace FoodOrdering.Presentation.ViewModels.User
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please enter your name!")]
        [StringLength(100)]
        public string Name { get;  set; }

        [Required(ErrorMessage = "Please enter your surname!")]
        [StringLength(100)]
        public string Surname { get;  set; }

        [Required(ErrorMessage = "Email not specified")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password not specified")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password entered incorrectly")]
        public string ConfirmPassword { get; set; }
    }
}
