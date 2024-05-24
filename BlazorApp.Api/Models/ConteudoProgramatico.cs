namespace BlazorApp.Api.Models;

public class ConteudoProgramatico
{
    public Guid Id { get; set; }
    public string Assunto { get; set; } = string.Empty;
    public int CargaHoraria { get; set; }
    public int Status { get; set; }
}