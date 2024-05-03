namespace BlazorApp.Api.Models;

public class Empresa
{
    public Guid Id { get; set; }
    public string CNPJ { get; set; } = string.Empty;
    public string RazaoSocial { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int Status { get; set; }
}