using FactoryProject.Contracts;
using FactoryProject.Models.CategoryDtos;

using Newtonsoft.Json;

namespace FactoryProject.Services;

public class CategoryManager : ICategoryService
{
    private readonly HttpClient _client;
    public CategoryManager(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient("FactoryApi");
    }
    public Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCategoryAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ResultCategoryDto>> GetAllCategoriesAsync()
    {
        var response = await _client.GetAsync("category");
        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            throw new Exception("An error occured while fetching data from api");
        var jsonData = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData)!;
    }

    public async Task<ResultCategoryDto> GetCategoryByIdAsync(int id)
    {
        var categories = await GetAllCategoriesAsync();
        return  categories.FirstOrDefault(c => c.Id.Equals(id))!;
      
    }

    public Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
    {
        throw new NotImplementedException();
    }
}