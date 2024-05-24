namespace BlazorApp.Web.Models;

public class Prova
{
    public Guid Id {get; set;}
    public DateTime DataRealizacao { get; set; }
    public int Status { get; set; }
    public Guid PessoaId {get; set;}
}