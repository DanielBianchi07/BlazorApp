using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface ICursoSqlRepository
{
    void Create(Curso curso);
    IEnumerable<Curso> Read();
    Curso Read(Guid id);
    void Update(Curso curso, Guid id);
    void Delete(Guid id);
}