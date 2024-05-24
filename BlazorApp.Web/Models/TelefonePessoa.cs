namespace BlazorApp.Web.Models;

public class TelefonePessoa
{
    public Guid Id { get; set; }
    public Guid PessoaId { get; set; }  
    public string NroTelefone { get; set; } = string.Empty;
    public int Status { get; set; }
}