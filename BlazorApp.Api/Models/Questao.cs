namespace BlazorApp.Api.Models;

public class Questao
{
    public Guid Id { get; set; }
    public string Conteudo { get; set; } = string.Empty;
    public int Status { get; set; }
}