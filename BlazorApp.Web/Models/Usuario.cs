namespace BlazorApp.Web.Models;

public class Usuario
{
    public Guid PessoaId {get; set;}
    public string Senha { get; set; } = string.Empty;
    public int Status { get; set; }
}