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
        var response = await _client.GetAsync($"cart/add?quantity={createcartdto.quantity}&productId={createcartdto.productId}");
        return response.IsSuccessStatusCode;
    }
    public async Task<bool> DeleteCartAsync(int id)
    {
        var response = await _client.DeleteAsync($"cart/delete?cartId={id}");
        return response.IsSuccessStatusCode;
    }

    public async Task<List<ResultCartDto>> GetAllCartAsync()
    {
        var response = await _client.GetAsync("cart");
        if (!response.IsSuccessStatusCode)
            return [];
        var jsonData = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<ResultCartDto>>(jsonData)!;
    }

    public async Task<ResultCartDto> GetCartByIdAsync(int cartId)
    {
        var carts = await GetAllCartAsync();
        return carts.FirstOrDefault(c => c.id.Equals(cartId))!;
    }

    public async Task<List<ResultCartDto>> GetCartsByUser()
    {
        var response = await _client.GetAsync($"cart");
        if (!response.IsSuccessStatusCode)
            throw new Exception("There is may be no cart for this user");
        var jsonData = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<ResultCartDto>>(jsonData)!;
    }
    public async Task<bool> UpdateCartAsync(UpdateCartDto updatecartdto)
    {
        var response = await _client
                    .GetAsync($"cart/update?cartId={updatecartdto.cartId}&quantity={updatecartdto.quantity}");
        return response.IsSuccessStatusCode;
    }
}