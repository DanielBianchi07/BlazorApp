using Microsoft.Extensions.Configuration;
using BlazorApp.Web.Models;

namespace BlazorApp.Web.Services;

public class CidadeService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public CidadeService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _baseUrl = configuration["AppSettings:BaseUrl"];
    }

    public async Task<List<Cidade>> GetCidadesAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Cidade>>(_baseUrl + "api/Cidade");
    }

    /*public async Task<Cidade> GetCidadeIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Cidade>($"api/Cidade/{id}");
    }*/

    public async Task<HttpResponseMessage> CriarCidadeAsync(Cidade cidade)
    {
        return await _httpClient.PostAsJsonAsync(_baseUrl + $"api/Cidade", cidade);
    }

    public async Task<HttpResponseMessage> AtualizarCidadeAsync(Guid id, Cidade cidade)
    {
        return await _httpClient.PutAsJsonAsync(_baseUrl + $"api/Cidade/{id}", cidade);
    }

    public async Task<HttpResponseMessage> ExcluirCidadeAsync(Guid id)
    {
        return await _httpClient.DeleteAsync(_baseUrl + $"api/Cidade/{id}");
    }
}
