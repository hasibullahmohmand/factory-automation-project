using FactoryProject.Models.CategoryDtos;

namespace FactoryProject.Models.ProductDtos;

 public class ResultProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string ImageUrl { get; set; }= String.Empty;
    public string Description { get; set; }= String.Empty;
    public int Stock { get; set; }
    public decimal Price { get; set; }
    public ResultCategoryDto? Category { get; set; }
}
