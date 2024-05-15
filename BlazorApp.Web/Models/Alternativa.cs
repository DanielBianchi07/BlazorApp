namespace BlazorApp.Web.Models;

public class Alternativa
{
    public Guid Id { get; set; }
    public string Conteudo { get; set; } = string.Empty;
    public int Status { get; set; }
    public Guid QuestaoId { get; set; }
}