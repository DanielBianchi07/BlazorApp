using System.ComponentModel.DataAnnotations;
namespace BlazorApp.Web.Models;

public class TelefoneEmpresa
{
    public Guid Id { get; set; }
    public Guid EmpresaId { get; set; }
    [StringLength(18)]
    public string NroTelefone { get; set; } = string.Empty;
}