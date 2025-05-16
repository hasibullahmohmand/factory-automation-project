namespace FactoryProject.Models.CartDtos;

public class CreateCartDto
{
    public int productId { get; set; }
    public int quantity { get; set; } = 50;
}