using System.ComponentModel.DataAnnotations;

namespace FactoryProject.Models.UserDtos;

public class LoginModel
    {
        [Required(ErrorMessage = "Email field is required!")]
        public string email { get; set; }=String.Empty;
        [Required(ErrorMessage = "Password field is required!")]
        public string password { get; set; }=String.Empty;

    }