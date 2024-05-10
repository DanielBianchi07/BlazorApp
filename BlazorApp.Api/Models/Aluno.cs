namespace BlazorApp.Api.Models;

public class Aluno
{
    public Guid PessoaId { get; set; }
    public string CPF { get; set; } = string.Empty;
    public string RG { get; set; } = string.Empty;
    public string Assinatura { get; set; } = string.Empty;
    public Guid UsuarioId { get; set; }
}