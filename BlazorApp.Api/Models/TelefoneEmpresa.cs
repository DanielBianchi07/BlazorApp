using System.ComponentModel.DataAnnotations;
namespace BlazorApp.Api.Models;

public class TelefoneEmpresa
{
    public Guid Id { get; set; }
    public Guid EmpresaId { get; set; }
    public string NroTelefone { get; set; } = string.Empty;
}