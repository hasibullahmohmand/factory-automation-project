using FactoryProject.Models.IngredientDtos;

namespace FactoryProject.Contracts;

public interface IIngredientService
{
    Task<bool> CreateIngredientAsync(CreateIngredientDto createIngredientDto);
    Task<List<ResultIngredientDto>> GetAllIngredientsAsync();
}