namespace FactoryProject.Models.IngredientDtos;

public class ResultIngredientDto
{
    public int id { get; set; }
    public string name { get; set; } = String.Empty;
    public int stock { get; set; }
    public DateTime expireDate { get; set; }
    public string unit { get; set; }
}
