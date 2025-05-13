using FactoryProject.Models;
using FactoryProject.Models.CartDtos;

namespace FactoryProject.Contracts;

public interface ICartService
{
    Task<bool> CreateCartAsync(CreateCartDto createcartdto);
    Task<bool> DeleteCartAsync(int id);
    Task<List<ResultCartDto>> GetAllCartAsync();
    Task<List<ResultCartDto>> GetCartsByUser(int userId);
    Task<ResultCartDto> GetCartByIdAsync(int cartId);
    Task<bool> UpdateCartAsync(UpdateCartDto updatecartdto);
    
}