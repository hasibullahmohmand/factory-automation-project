using System.ComponentModel.DataAnnotations;

namespace FactoryProject.Models.PersonalDtos
{
    public class PersonalForUpdateDto
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Name field is required")]
        public string name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Age field is required")]
        public int age { get; set; }
        [Required(ErrorMessage = "Gender field is required")]
        public int gender { get; set; }
        [Required(ErrorMessage = "Date field is required")]
        public DateTime date { get; set; }
        [Required(ErrorMessage = "department field is required")]
        public int departmentId { get; set; }
        [Required(ErrorMessage = "Identifier field is required")]
        public string identifier { get; set; } = string.Empty;
        [Required(ErrorMessage = "Shift field is required")]
        public string shift { get; set; } = string.Empty;
    }
}
