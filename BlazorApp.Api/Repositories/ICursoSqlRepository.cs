using BlazorApp.Api.Models;
// model = Curso
// variavel model = curso

public interface ICursoRepository
{
    void Create(Curso curso);
    IEnumerable<Curso> Read();
    void Update(Curso curso, Guid id);
    void Delete(Guid id);
}