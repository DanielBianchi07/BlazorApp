using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface ICursoConteudoSqlRepository
{
    void Create(CursoConteudo cursoConteudo);
    IEnumerable<CursoConteudo> Read();
    IEnumerable<CursoConteudo> Read(Guid idCurso, Guid idConteudo);
    void Update(CursoConteudo cursoConteudo, Guid idCurso, Guid idConteudo);
    void Delete(Guid idCurso, Guid idConteudo);
}