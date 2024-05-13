namespace BlazorApp.Web.Models;

public class Treinamento
{
    public Guid Id { get; set; }
    public int Tipo { get; set; }
    public int Status { get; set; }
    public Guid CursoId { get; set; }
}