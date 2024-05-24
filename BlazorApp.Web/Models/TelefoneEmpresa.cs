namespace BlazorApp.Web.Models;

public class TelefoneEmpresa
{
    public Guid Id { get; set; }
    public Guid EmpresaId { get; set; }
    public string NroTelefone { get; set; } = string.Empty;
    public int Status { get; set; }
}