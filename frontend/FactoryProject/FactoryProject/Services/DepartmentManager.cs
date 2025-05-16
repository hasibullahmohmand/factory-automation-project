using System.Text;
using FactoryProject.Contracts;
using FactoryProject.Models;
using Newtonsoft.Json;

namespace FactoryProject.Services;

public class DepartmentManager : IDepartmentService
{
    private readonly HttpClient _client;

    public DepartmentManager(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient("FactoryApi");
    }

    public async Task<bool> CreateDepartmentAsync(CreateDepartmentDto createDepartmentDto)
    {
        var jsonData = JsonConvert.SerializeObject(createDepartmentDto);
        var payload = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("personal/add", content: payload);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteDeprtmentAsync(int id)
    {
        var response = await _client.DeleteAsync($"personal/delete/{id}");
        return response.IsSuccessStatusCode;
    }

    public async Task<List<ResultDepartmentDto>> GetAllDepartmentAsync()
    {
        var response = await _client.GetAsync("personal");
        if (!response.IsSuccessStatusCode)
            return [];
        var jsonData = await response.Content.ReadAsStringAsync();
        var personals = JsonConvert.DeserializeObject<List<ResultDepartmentDto>>(jsonData);
        return personals!;
    }

    public async Task<ResultDepartmentDto> GetDepartmentByIdAsync(int id)
    {
        var personals = await GetAllDepartmentAsync();
        return personals.FirstOrDefault(per=>per.id.Equals(id))!;
    }

    public async Task<bool> UpdateDepartmentAsync(UpdateDepartmentDto updateDepartmentDto)
    {
        var jsonData = JsonConvert.SerializeObject(updateDepartmentDto);
        var payload = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("personal/add", content: payload);
        return response.IsSuccessStatusCode;
    }
}