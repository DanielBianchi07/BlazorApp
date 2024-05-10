using System.ComponentModel.DataAnnotations;
namespace BlazorApp.Api.Models;

public class Prova
{
    public Guid Id {get; set;}

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
    public DateTime DataRealizacao { get; set; }
    public Guid PessoaId {get; set;}
}