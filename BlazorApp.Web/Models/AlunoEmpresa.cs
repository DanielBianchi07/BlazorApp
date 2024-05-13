namespace BlazorApp.Web.Models;

public class AlunoEmpresa
{
    public Guid AlunoId { get; set; }
    public Guid EmpresaId { get; set; }
    public int Status { get; set; }
}