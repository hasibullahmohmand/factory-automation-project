using FactoryProject.Models;
namespace FactoryProject.Contracts;
public interface IDepartmentService
{
    Task<bool> CreateDepartmentAsync(CreateDepartmentDto createDepartmentDto);
    Task<bool> UpdateDepartmentAsync(UpdateDepartmentDto updateDepartmentDto);
    Task<bool> DeleteDeprtmentAsync(int id);
    Task<List<ResultDepartmentDto>> GetAllDepartmentAsync();
    Task<ResultDepartmentDto> GetDepartmentByIdAsync(int id);
}