using FactoryProject.Models.OrderDtos;

namespace FactoryProject.Contracts;

public interface IOrderService
{
    Task<bool> CreateOrderAsync(CreateOrderDto createorderdto);
    Task<bool> UpdateOrderAsync(UpdateOrderDto updateorderdto);
    Task<List<ResultOrderDto>> GetAllOrderAsync();
    Task<ResultOrderDto> GetOrderByIdAsync(int orderId);
    Task<List<ResultOrderDto>> GetOrdersByUserAsync();
}