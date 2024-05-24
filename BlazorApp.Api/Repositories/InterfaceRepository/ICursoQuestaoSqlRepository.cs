using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface ICursoQuestaoSqlRepository
{
    void Create(CursoQuestao cursoQuestao);
    IEnumerable<CursoQuestao> Read();
    IEnumerable<CursoQuestao> Read(Guid idCurso, Guid idQuestao);
    void Update(CursoQuestao cursoQuestao, Guid idCurso, Guid idQuestao);
    void Delete(Guid idCurso, Guid idQuestao);
}