using FactoryProject.Models;
using FactoryProject.Models.CategoryDtos;
using FactoryProject.Models.IngredientDtos;
using FactoryProject.Models.ProductDtos;

namespace FactoryProject.Infrastructure.Utilities.Services;

public class GenericStateService<T>
{
    public string SuccessMessage { get; set; } = string.Empty;
    public string ErrorMessage { get; set; } = string.Empty;
    private List<T> _models = [];
    public event Action? OnModelsChanged;
    public List<T> Models
    {
        get => _models;
        set
        {
            _models = value;
            OnModelsChanged?.Invoke();
        }
    }
    public void SetItems(List<T> models)
    {
        Models = models;
    }
    public void AddItem(T model)
    {
        //book.Id = _books.Count > 0 ? _books.Max(b => b.Id) + 1 : 1; // Assign a new ID
        _models.Add(model);
        var msg = $"An new item is successfully added.";
        SetSuccessMessage(msg);
        OnModelsChanged?.Invoke();
    }
    public void RemoveItem(T model)
    {
        if(model == null) return;
        _models.Remove(model);
        var msg = $"An item is successfully deleted.";
        SetSuccessMessage(msg);
        OnModelsChanged?.Invoke();
    }
    public void UpdateItem(T model, int index)
    {
        if (index != -1)
        {
            _models[index] = model;
            SetSuccessMessage($"An item is successfully updated.");
            OnModelsChanged?.Invoke();
        }
    }
    
    private void SetSuccessMessage(string message)
    {
        SuccessMessage = message;
        Task.Run(async () =>
        {
            await Task.Delay(5000);//5 seconds delay
            Reset();
        });
    }
    private void Reset()
    {
        SuccessMessage = string.Empty;
    }
}
public class ProductStateService: GenericStateService<ResultProductDto> { }
public class CategoryStateService: GenericStateService<ResultCategoryDto> { }
public class PersonalStateService: GenericStateService<ResultPersonalDto> { }
public class DepartmentStateService: GenericStateService<ResultDepartmentDto> { }
public class IngredientStateService: GenericStateService<ResultIngredientDto> { }