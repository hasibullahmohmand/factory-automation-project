using FactoryProject.Models;
using FactoryProject.Models.CategoryDtos;
namespace FactoryProject.Contracts;

public interface ICategoryService
{
    Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
    Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
    Task DeleteCategoryAsync(int id);
    Task<List<ResultCategoryDto>> GetAllCategoriesAsync();
    Task<ResultCategoryDto> GetCategoryByIdAsync(int id);
}

public interface IDepartmentService
{
    Task<bool> CreateDepartmentAsync(CreateDepartmentDto createDepartmentDto);
    Task<bool> DeleteDepartmentAsync(int departmentId);
    Task<bool> UpdateDepartmentAsync(UpdateDepartmentDto updateDepartmentDto);
}