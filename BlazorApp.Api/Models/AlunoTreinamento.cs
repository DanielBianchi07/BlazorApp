using System.ComponentModel.DataAnnotations;
namespace BlazorApp.Api.Models;

public class AlunoTreinamento
{
    public Guid PessoaId { get; set; }
    public Guid TreinamentoId { get; set; }
    
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
    public DateTime DataTreinamento { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
    public DateTime DataInicioCertificado { get; set; }
    public int Resultado { get; set; }
    //public Pessoa Pessoa { get; set; }
}