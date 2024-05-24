using System.ComponentModel.DataAnnotations;
namespace BlazorApp.Api.Models;

public class AlunoTreinamento
{
    public Guid PessoaId { get; set; }
    public Guid TreinamentoId { get; set; }
    public DateTime DataTreinamento { get; set; }
    public DateTime DataInicioCertificado { get; set; }
    public int Resultado { get; set; }
}