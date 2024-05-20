using Microsoft.Extensions.Configuration;
using BlazorApp.Web.Models;

namespace BlazorApp.Web.Services;

public class EnderecoEmpresaService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public EnderecoEmpresaService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _baseUrl = configuration["AppSettings:BaseUrl"];
    }

    public async Task<List<EnderecoEmpresa>> GetEnderecoEmpresaAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<EnderecoEmpresa>>(_baseUrl + "api/EnderecoEmpresa");
    }

    public async Task<EnderecoEmpresa> GetEnderecoEmpresaIdAsync(Guid idEmpresa)
    {
        return await _httpClient.GetFromJsonAsync<EnderecoEmpresa>(_baseUrl + $"api/EnderecoEmpresa/{idEmpresa}");
    }

    public async Task<HttpResponseMessage> CriarEnderecoEmpresaAsync(EnderecoEmpresa enderecoEmpresa)
    {
        return await _httpClient.PostAsJsonAsync(_baseUrl + $"api/EnderecoEmpresa", enderecoEmpresa);
    }

    public async Task<HttpResponseMessage> AtualizarEnderecoEmpresaAsync(Guid id, EnderecoEmpresa enderecoEmpresa)
    {
        return await _httpClient.PutAsJsonAsync(_baseUrl + $"api/EnderecoEmpresa/{id}", enderecoEmpresa);
    }

    public async Task<HttpResponseMessage> ExcluirEnderecoEmpresaAsync(Guid id)
    {
        return await _httpClient.DeleteAsync(_baseUrl + $"api/EnderecoEmpresa/{id}");
    }
}
