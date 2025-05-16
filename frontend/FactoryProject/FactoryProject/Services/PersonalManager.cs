using System.Text;
using FactoryProject.Contracts;
using FactoryProject.Models;
using FactoryProject.Models.PersonalDtos;
using Newtonsoft.Json;

namespace FactoryProject.Services;

public class PersonalManager : IPersonalService
{
    private readonly HttpClient _client;
    public PersonalManager(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient("FactoryApi");
    }

    public async Task<bool> CreatePersonalAsync(CreatePersonalDto createpersonaldto)
    {
        var jsonData = JsonConvert.SerializeObject(createpersonaldto);
        var payload = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("personal/add", payload);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeletePersonalAsync(int personalId)
    {
        var response = await _client.DeleteAsync($"personal/delete/{personalId}");
        return response.IsSuccessStatusCode;
    }

    public async Task<List<ResultPersonalDto>> GetAllPersonalAsync()
    {
        var response = await _client.GetAsync("personal");
        var jsonData = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<ResultPersonalDto>>(jsonData)!;
    }

    public async Task<ResultPersonalDto> GetPersonelByIdAsync(int personalId)
    {
        var personals = await GetAllPersonalAsync();
        return personals.FirstOrDefault(per => per.id == personalId)!;
    }

    public Task<bool> UpdatePersonalAsync(UpdatePersonalDto updatePersonalDto)
    {
        throw new NotImplementedException();
    }
}