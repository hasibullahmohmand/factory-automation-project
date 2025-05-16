namespace FactoryProject.Models.IngredientDtos;

public class UpdateIngredientDto
{
    public int id { get; set; }
    public string name { get; set; } = string.Empty;
    public int stock { get; set; }
    public DateTime expireDate { get; set; }
    public string unit{ get; set; }
}