using Microsoft.Extensions.Configuration;
using BlazorApp.Web.Models;

namespace BlazorApp.Web.Services;

public class TelefoneEmpresaService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public TelefoneEmpresaService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _baseUrl = configuration["AppSettings:BaseUrl"];
    }

    public async Task<List<TelefoneEmpresa>> GetTelefonesEmpresasAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<TelefoneEmpresa>>(_baseUrl + "api/TelefoneEmpresa");
    }

    public async Task<List<TelefoneEmpresa>> GetTelefoneEmpresaIdAsync(Guid idEmpresa)
    {
        return await _httpClient.GetFromJsonAsync<List<TelefoneEmpresa>>(_baseUrl + $"api/TelefoneEmpresa/{idEmpresa}");
    }

    public async Task<HttpResponseMessage> CriarTelefoneEmpresaAsync(TelefoneEmpresa telefoneEmpresa, Guid idEmpresa)
    {
        return await _httpClient.PostAsJsonAsync(_baseUrl + $"api/TelefoneEmpresa/{idEmpresa}", telefoneEmpresa);
    }

    public async Task<HttpResponseMessage> AtualizarTelefoneEmpresaAsync(Guid id, TelefoneEmpresa telefoneEmpresa)
    {
        return await _httpClient.PutAsJsonAsync(_baseUrl + $"api/TelefoneEmpresa/{id}", telefoneEmpresa);
    }

    public async Task<HttpResponseMessage> ExcluirTelefoneEmpresaAsync(Guid idTelefone)
    {
        return await _httpClient.DeleteAsync(_baseUrl + $"api/TelefoneEmpresa/{idTelefone}");
    }
}
