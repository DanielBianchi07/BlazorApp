namespace BlazorApp.Web.Models;

public class Instrutor
{
    public Guid PessoaId { get; set; }
    public string Especializacao { get; set; } = string.Empty;
    public string Assinatura { get; set; } = string.Empty;
    public string Registro { get; set; } = string.Empty;
    public int Status { get; set; }
}