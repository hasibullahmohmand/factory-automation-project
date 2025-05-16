using FactoryProject.Infrastructure.Utilities;
using FactoryProject.Models.ProductDtos;    

namespace FactoryProject.Contracts;
public interface IProductService
{
    public Task<bool> CreateProductAsync(ProductForInsertionDto createProductDto);
    public Task<bool> UpdateProductAsync(UpdateProductDto updateProductDto);
    public Task<bool> DeleteProductAsync(int id);
    public Task<List<ResultProductDto>> GetAllProductsAsync();
    public Task<PagedList<ResultProductDto>> GetAllProductsWithPaginationAsync(RequestParameters requestParameter);
    public Task<List<ResultProductDto>> GetProductByCateogryIdAsync(int id);
    public Task<ResultProductDto> GetProductByIdAsync(int id);
}