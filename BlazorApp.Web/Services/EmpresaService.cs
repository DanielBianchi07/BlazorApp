using Microsoft.Extensions.Configuration;
using BlazorApp.Web.Models;

namespace BlazorApp.Web.Services;

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

    /*public async Task<Empresa> GetEmpresaIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Empresa>($"api/Empresa/{id}");
    }*/

    public async Task<Empresa> CriarEmpresaAsync(Empresa empresa)
    {
        var response = await _httpClient.PostAsJsonAsync(_baseUrl + "api/Empresa", empresa);
        return await response.Content.ReadFromJsonAsync<Empresa>();
    }

    public async Task<HttpResponseMessage> AtualizarEmpresaAsync(Guid id, Empresa Empresa)
    {
        return await _httpClient.PutAsJsonAsync(_baseUrl + $"api/Empresa/{id}", Empresa);
    }

    public async Task<HttpResponseMessage> ExcluirEmpresaAsync(Guid id)
    {
        return await _httpClient.DeleteAsync(_baseUrl + $"api/Empresa/{id}");
    }
}
