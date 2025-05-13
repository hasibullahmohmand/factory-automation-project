using System.Text;
using FactoryProject.Contracts;
using FactoryProject.Models;
using FactoryProject.Models.CartDtos;
using Newtonsoft.Json;

namespace FactoryProject.Services;

public class CartManager : ICartService
{
    private readonly HttpClient _client;
    public CartManager(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient("FactoryApi");
    }

    public async Task<bool> CreateCartAsync(CreateCartDto createcartdto)
    {
        var response = await _client.GetAsync($"cart/add?{createcartdto.quantity}&{createcartdto.productId}");
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteCartAsync(int id)
    {
        var response = await _client.DeleteAsync($"cart/{id}");
        return response.IsSuccessStatusCode;
    }

    public Task<List<ResultCartDto>> GetAllCartAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ResultCartDto> GetCartByIdAsync(int cartId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ResultCartDto>> GetCartsByUser(int userId)
    {
        var response = await _client.GetAsync($"cart/{userId}");
        if (!response.IsSuccessStatusCode)
            throw new Exception("There is may be no cart for this user");
        var jsonData = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<ResultCartDto>>(jsonData)!;
    }

    public Task<bool> UpdateCartAsync(UpdateCartDto updatecartdto)
    {
        throw new NotImplementedException();
    }
}