using Microsoft.Extensions.Configuration;
using BlazorApp.Web.Models;

namespace BlazorApp.Web.Services;

public class EstadoService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public EstadoService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _baseUrl = configuration["AppSettings:BaseUrl"];
    }

    public async Task<List<Estado>> GetEstadosAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Estado>>(_baseUrl + "api/Estado");
    }

    /*public async Task<Estado> GetEstadoIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Estado>($"api/Estado/{id}");
    }*/

    public async Task<HttpResponseMessage> CriarEstadoAsync(Estado estado)
    {
        return await _httpClient.PostAsJsonAsync(_baseUrl + $"api/Estado", estado);
    }

    public async Task<HttpResponseMessage> AtualizarEstadoAsync(Guid id, Estado estado)
    {
        return await _httpClient.PutAsJsonAsync(_baseUrl + $"api/Estado/{id}", estado);
    }

    public async Task<HttpResponseMessage> ExcluirEstadoAsync(Guid id)
    {
        return await _httpClient.DeleteAsync(_baseUrl + $"api/Estado/{id}");
    }
}
