using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface ICursoQuestaoRepository
{
    void Create(CursoQuestao cursoQuestao);
    IEnumerable<CursoQuestao> Read();
    void Update(CursoQuestao cursoQuestao, Guid id);
    void Delete(Guid id);
}