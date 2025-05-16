using FactoryProject.Models.CategoryDtos;

namespace FactoryProject.Models.ProductDtos;

public class ProductForInsertionDto
{
    public string name { get; set; } = String.Empty;
    public string description { get; set; } = String.Empty;
    public decimal price { get; set; }
    public string imageUrl { get; set; } = String.Empty;
    public int stock { get; set; }
    public ResultCategoryDto? category { get; set; }
}