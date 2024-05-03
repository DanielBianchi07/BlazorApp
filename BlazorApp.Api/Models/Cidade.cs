namespace BlazorApp.Api.Models;

public class Cidade
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public Guid EstadoId { get; set; }
}