using System.ComponentModel.DataAnnotations;
using FactoryProject.Models.CategoryDtos;

namespace FactoryProject.Models.ProductDtos;

public class CreateProductDto
{
    [Required(ErrorMessage = "Name field is required")]
    [MinLength(4, ErrorMessage = "Name of product must be at least 4 characters")]
    public string name { get; set; } = String.Empty;
    [Required(ErrorMessage = "Description field is required")]
    [MinLength(15, ErrorMessage = "Description must be at least 15 characters")]
    public string description { get; set; } = String.Empty;
    [Range(1, 500, ErrorMessage = "Price must be between 1 and 500")]
    public decimal price { get; set; }
    [Required(ErrorMessage = "Image url is required")]
    public string imageUrl { get; set; } = String.Empty;
    public int stock { get; set; }
    public ResultCategoryDto? category { get; set; }
    public int CategoryId { get; set; }
}
