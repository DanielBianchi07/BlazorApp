using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using BlazorApp.Web.Models;

namespace BlazorApp.Web.Services;

public class UsuarioService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;    

    public UsuarioService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _baseUrl = configuration["AppSettings:BaseUrl"];
    }

    public async Task<List<Usuario>> GetUsuariosAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Usuario>>(_baseUrl + "api/Usuario");
    }

    public async Task<Usuario> GetUsuarioIdAsync(Guid id)
    {
        return await _httpClient.GetFromJsonAsync<Usuario>(_baseUrl + $"api/Usuario/{id}");
    }

    public async Task<Usuario> CriarUsuarioAsync(Usuario Usuario)
    {
        var response = await _httpClient.PostAsJsonAsync(_baseUrl + "api/Usuario", Usuario);
        return await response.Content.ReadFromJsonAsync<Usuario>();
    }

    public async Task<HttpResponseMessage> AtualizarUsuarioAsync(Guid id, Usuario Usuario)
    {
        return await _httpClient.PutAsJsonAsync(_baseUrl + $"api/Usuario/{id}", Usuario);
    }

    public async Task<HttpResponseMessage> ExcluirUsuarioAsync(Guid id)
    {
        return await _httpClient.DeleteAsync(_baseUrl + $"api/Usuario/{id}");
    }


    public async Task<bool> LoginAsync(string nome, string senha)
    {
        var usuario = await GetUsuarioIdAsync(usuario.Id);
        if (user == null)
        {
            return false;
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        await _httpContextAccessor.HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity));

        return true;
    }







}
