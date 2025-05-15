using System.Text;
using FactoryProject.Contracts;
using FactoryProject.Models.OrderDtos;
using Newtonsoft.Json;

namespace FactoryProject.Services;

public class OrderManager: IOrderService
{
    private readonly HttpClient _client;
    public OrderManager(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient("FactoryApi");
    }

    public async Task<bool> CreateOrderAsync(CreateOrderDto createorderdto)
    {
        var jsonData = JsonConvert.SerializeObject(createorderdto);
        var payload = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("order/add", content: payload);
        return response.IsSuccessStatusCode;
    }

    public async Task<List<ResultOrderDto>> GetAllOrderAsync()
    {
        var response = await _client.GetAsync("order/get");
        var jsonData = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<ResultOrderDto>>(jsonData)!;
        
    }

    public async Task<ResultOrderDto> GetOrderByIdAsync(int orderId)
    {
        var orders = await GetAllOrderAsync();
        return orders.FirstOrDefault(or => or.id == orderId)!;
    }

    public Task<List<ResultOrderDto>> GetOrdersByUserAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateOrderAsync(UpdateOrderDto updateorderdto)
    {
        var jsonData = JsonConvert.SerializeObject(updateorderdto);
        var payload = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = await _client.PutAsync("order/update", content: payload);
        return response.IsSuccessStatusCode;
    }
}