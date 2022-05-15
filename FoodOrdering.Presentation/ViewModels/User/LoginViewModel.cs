using System.ComponentModel.DataAnnotations;

namespace FoodOrdering.Presentation.ViewModels.User
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email not specified")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password not specified")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
