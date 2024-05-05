using BlazorApp.Api.Models;
// model = CursoQuestao
// variavel model = cursoQuestao

public interface ICursoQuestaoRepository
{
    void Create(CursoQuestao cursoQuestao);
    IEnumerable<CursoQuestao> Read();
    void Update(CursoQuestao cursoQuestao, Guid id);
    void Delete(Guid id);
}