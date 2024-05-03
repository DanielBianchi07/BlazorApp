using Microsoft.Extensions.Configuration;
using BlazorApp.Api.Models;

public class EmpresaService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public EmpresaService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _baseUrl = configuration["AppSettings:BaseUrl"];
    }

    public async Task<List<Empresa>> GetEmpresasAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Empresa>>(_baseUrl + "api/Empresa");
    }

//    public async Task<Empresa> GetEmpresaIdAsync(int id)
//    {
//        return await _httpClient.GetFromJsonAsync<Empresa>($"api/Empresa/{id}");
 //   }

    public async Task<HttpResponseMessage> CriarEmpresaAsync(Empresa empresa)
    {
        return await _httpClient.PostAsJsonAsync(_baseUrl + "api/Empresa", empresa);
    }

    public async Task<HttpResponseMessage> AtualizarEmpresaAsync(int id, Empresa Empresa)
    {
        return await _httpClient.PutAsJsonAsync(_baseUrl + $"api/Empresa/{id}", Empresa);
    }

    public async Task<HttpResponseMessage> ExcluirEmpresaAsync(int id)
    {
        return await _httpClient.DeleteAsync(_baseUrl + $"api/Empresa/{id}");
    }
}
