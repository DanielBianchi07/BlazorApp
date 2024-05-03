namespace BlazorApp.Api.Models;

public class CursoQuestao
{
    public Guid CursoId { get; set; }
    public Guid QuestaoId { get; set; }
    public int Status { get; set; }
}