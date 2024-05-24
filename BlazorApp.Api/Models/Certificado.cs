using System.ComponentModel.DataAnnotations;
namespace BlazorApp.Api.Models;

public class Certificado
{
    public Guid TreinamentoId { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public DateTime DataEmissao { get; set; }
    public int Situacao { get; set; }
}