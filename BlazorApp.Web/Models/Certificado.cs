using System.ComponentModel.DataAnnotations;
namespace BlazorApp.Web.Models;

public class Certificado
{
    public Guid TreinamentoId { get; set; }
    public string Codigo { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
    public DateTime DataEmissao { get; set; }
    public int Status { get; set; }
}