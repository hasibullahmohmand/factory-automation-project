namespace FactoryProject.Models.IngredientDtos;

public class ResultIngredientDto
{
    public int id { get; set; }
    public string name { get; set; } = String.Empty;
    public int stock { get; set; }
    public DateTime expireDate { get; set; }
    public Unit unit { get; set; }
}
public class CreateIngredientDto
{
    public string name { get; set; } = string.Empty;
    public int stock { get; set; }
    public DateTime expireDate { get; set; }
    public Unit unit{ get; set; }
}