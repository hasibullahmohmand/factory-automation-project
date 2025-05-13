namespace FactoryProject.Models.OrderDtos;

public class ResultOrderDto
{
    public int id { get; set; }
    public ResultCartDto? cart { get; set; }
    public DateTime deliveryDate { get; set; }
    public bool delivered { get; set; } = false;
}