namespace BlazorApp.Api.Models;

public class Usuario
{
    public Guid PessoaId {get; set;}
    public string Nome { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public int Status { get; set; }
}