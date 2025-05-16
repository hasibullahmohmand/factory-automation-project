using System.Text;
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
    public async Task<bool> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
    {
        var jsonData = JsonConvert.SerializeObject(createCategoryDto);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("category/add", content);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        var response = await _client.DeleteAsync($"category/delete/{id}");
        return response.IsSuccessStatusCode;
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

    public async Task<HttpResponseMessage> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
    {
            var jsonData = JsonConvert.SerializeObject(updateCategoryDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("category/update", content);
            return response;
    }
}