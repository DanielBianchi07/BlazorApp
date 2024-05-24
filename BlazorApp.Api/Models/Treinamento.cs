namespace BlazorApp.Api.Models;

public class Treinamento
{
    public Guid Id { get; set; }
    public int Tipo { get; set; }
    public int Situacao { get; set; }
    public Guid CursoId { get; set; }
    public Guid ProvaId { get; set; }
    public int Status { get; set; }
}