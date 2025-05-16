namespace FactoryProject.Models.IngredientDtos;

public class CreateIngredientDto
{
    public string name { get; set; } = string.Empty;
    public int stock { get; set; }
    public DateTime expireDate { get; set; }
    public string unit{ get; set; }
}
