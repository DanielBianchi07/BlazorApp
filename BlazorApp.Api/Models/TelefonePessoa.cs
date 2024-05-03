using System.ComponentModel.DataAnnotations;
namespace BlazorApp.Api.Models;

public class TelefonePessoa
{
    public Guid Id { get; set; }
    public Guid PessoaId { get; set; }
  
    [DataType(DataType.PhoneNumber)]
    [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$")]
    public string NroTelefone { get; set; } = string.Empty;
}