namespace BlazorApp.Web.Models;

public class ListaPresenca
{
    public Guid TreinamentoId { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public DateTime DataEmissao { get; set; }
}