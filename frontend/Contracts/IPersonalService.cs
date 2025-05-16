using FactoryProject.Models;
using FactoryProject.Models.PersonalDtos;

namespace FactoryProject.Contracts;

public interface IPersonalService
{
    Task<bool> CreatePersonalAsync(CreatePersonalDto createpersonaldto);
    Task<bool> DeletePersonalAsync(int personalId);
    Task<List<ResultPersonalDto>> GetAllPersonalAsync();
    Task<ResultPersonalDto> GetPersonelByIdAsync(int personalId);
    Task<bool> UpdatePersonalAsync(UpdatePersonalDto updatePersonalDto);
}