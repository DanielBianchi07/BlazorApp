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

    public async Task<Guid> CriarEmpresaAsync(Empresa empresa)
    {
    HttpResponseMessage response = await _httpClient.PostAsJsonAsync(_baseUrl + "api/Empresa", empresa);
    
    if (response.IsSuccessStatusCode)
    {
        // Extrai o ID da empresa da resposta da API como string
        string empresaIdString = await response.Content.ReadAsStringAsync();

        // Converte a string para um Guid
        Guid empresaId;
        if (Guid.TryParse(empresaIdString, out empresaId))
        {
            return empresaId;
        }
        else
        {
            // Se a conversão falhar, você pode tratar o erro aqui
            throw new Exception("Falha ao converter o ID da empresa.");
        }
        }
        else
        {
        // Se a criação da empresa falhar, você pode tratar o erro aqui
        // Por exemplo, lançar uma exceção, logar o erro, etc.
        throw new Exception("Falha ao criar a empresa: " + response.ReasonPhrase);
        }
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
