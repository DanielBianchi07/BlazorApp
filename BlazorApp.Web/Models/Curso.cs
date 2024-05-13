namespace BlazorApp.Web.Models;

public class Curso
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Logo { get; set; } = string.Empty;
    public int CargaHorariaInicial { get; set; }
    public int CargaHorariaPeriodico { get; set; }
    public int Validade { get; set; }
    public int Status { get; set; }
}