using System.ComponentModel.DataAnnotations;

namespace FactoryProject.Models.UserDtos;
public class RegisterModel
{
    [Required(ErrorMessage = "UserName field is required")]
    [MinLength(3, ErrorMessage = "UserName must be at least 3 characters long")]
    [MaxLength(20, ErrorMessage = "UserName must be at most 20 characters long")]
    public string? username { get; set; }
    [Required(ErrorMessage = "Email field is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    [MaxLength(15, ErrorMessage = "Email must be at most 50 characters long")]
    public string? email { get; set; }
    [Required(ErrorMessage = "Password field is required")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{6,}$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, and one number.")]
    public string? password { get; set; }
   
    [Required(ErrorMessage = "Password field is required")]
    [StringLength(13, ErrorMessage = "Phone number must be 11 digits long", MinimumLength = 11)]
    public string? phone { get; set; }
    
    [Required(ErrorMessage = "Address field is required!")]
    public string? address { get; set; }
 
}