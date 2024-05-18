using System.ComponentModel.DataAnnotations;
namespace BlazorApp.Web.Models;

public class TelefoneEmpresa
{
    public Guid Id { get; set; }
    public Guid EmpresaId { get; set; }
  
    //[DataType(DataType.PhoneNumber)]
    //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$")]
    public string NroTelefone { get; set; } = string.Empty;
}