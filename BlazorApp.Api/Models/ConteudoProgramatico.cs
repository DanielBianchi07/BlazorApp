namespace BlazorApp.Api.Models;

public class ConteudoProgramatico
{
    public readonly Guid Id;
    public string Assunto { get; set; } = string.Empty;
    public int CargaHoraria { get; set; }
}