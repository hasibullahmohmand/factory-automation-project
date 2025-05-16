using FactoryProject.Models.IngredientDtos;

namespace FactoryProject.Contracts;

public interface IIngredientService
{
    Task<bool> CreateIngredientAsync(CreateIngredientDto createIngredientDto);
    Task<List<ResultIngredientDto>> GetAllIngredientsAsync();
    Task<bool> UpdateIngredientAsync(UpdateIngredientDto updateIngredientDto);
    Task<bool> DeleteIngredientAsync(int  id);
    Task<ResultIngredientDto> GetIngredientByIdAsync(int id);
}