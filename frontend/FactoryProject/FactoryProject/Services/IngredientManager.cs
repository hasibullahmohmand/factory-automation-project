using FactoryProject.Contracts;
using FactoryProject.Models.IngredientDtos;
using Newtonsoft.Json;
using System.Net.WebSockets;
using System.Text;

namespace FactoryProject.Services;

public class IngredientManager : IIngredientService
{
    private readonly HttpClient _client;
    public IngredientManager(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient("FactoryApi");
    }
    public async Task<bool> CreateIngredientAsync(CreateIngredientDto createIngredientDto)
    {
        var jsonData= JsonConvert.SerializeObject(createIngredientDto);
        var content=new StringContent(jsonData,Encoding.UTF8,"application/json");
        var response=await _client.PostAsync(jsonData, content);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteIngredientAsync(int id)
    {
        var response = await _client.DeleteAsync($"delete/{id}");
        return response.IsSuccessStatusCode;
    }

    public async Task<List<ResultIngredientDto>> GetAllIngredientsAsync()
    {
        var response = await _client.GetAsync("ingredient");
        if (!response.IsSuccessStatusCode)
            return [];
        var jsonData= await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<ResultIngredientDto>>(jsonData)!;
    }
    public async Task<ResultIngredientDto> GetIngredientByIdAsync(int id)
    {
        var ingredients=await GetAllIngredientsAsync();
        return ingredients.FirstOrDefault(i => i.id == id)!;
    }
    public async Task<bool> UpdateIngredientAsync(UpdateIngredientDto ingredientDto)
    {
        var jsonData = JsonConvert.SerializeObject(ingredientDto);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = await _client.PutAsync(jsonData, content);
        return response.IsSuccessStatusCode;
    }
}