using FactoryProject.Models;
using FactoryProject.Models.CategoryDtos;
namespace FactoryProject.Contracts;

public interface ICategoryService
{
    Task<bool> CreateCategoryAsync(CreateCategoryDto createCategoryDto);
    Task<HttpResponseMessage> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
    Task<bool> DeleteCategoryAsync(int id);
    Task<List<ResultCategoryDto>> GetAllCategoriesAsync();
    Task<ResultCategoryDto> GetCategoryByIdAsync(int id);
}

