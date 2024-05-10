using System.ComponentModel.DataAnnotations;
namespace BlazorApp.Api.Models;

public class ListaPresenca
{
    public Guid TreinamentoId { get; set; }
    public string Codigo { get; set; } = string.Empty;
  
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
    public DateTime DataEmissao { get; set; }
}