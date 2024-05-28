using Microsoft.Extensions.Configuration;
using BlazorApp.Web.Models;

namespace BlazorApp.Web.Services;

public class PessoaService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public PessoaService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _baseUrl = configuration["AppSettings:BaseUrl"];
    }

    public async Task<List<Pessoa>> GetPessoasAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Pessoa>>(_baseUrl + "api/Pessoa");
    }

    public async Task<Pessoa> GetPessoaIdAsync(Guid id)
    {
        return await _httpClient.GetFromJsonAsync<Pessoa>(_baseUrl + $"api/Pessoa/{id}");
    }

    public async Task<Pessoa> CriarPessoaAsync(Pessoa Pessoa)
    {
        var response = await _httpClient.PostAsJsonAsync(_baseUrl + "api/Pessoa", Pessoa);
        return await response.Content.ReadFromJsonAsync<Pessoa>();
    }

    public async Task<HttpResponseMessage> AtualizarPessoaAsync(Guid id, Pessoa Pessoa)
    {
        return await _httpClient.PutAsJsonAsync(_baseUrl + $"api/Pessoa/{id}", Pessoa);
    }

    public async Task<HttpResponseMessage> ExcluirPessoaAsync(Guid id)
    {
        return await _httpClient.DeleteAsync(_baseUrl + $"api/Pessoa/{id}");
    }
}
