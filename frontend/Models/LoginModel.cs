using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email required!")]
        public string email { get; set; }
        [Required(ErrorMessage = "Password required!")]
        public string password { get; set; }

    }
}
