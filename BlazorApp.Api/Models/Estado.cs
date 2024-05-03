namespace BlazorApp.Api.Models;

public class Estado
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string UF { get; set; } = string.Empty;
}