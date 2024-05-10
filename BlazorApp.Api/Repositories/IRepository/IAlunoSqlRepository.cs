using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface IAlunoSqlRepository
{
    void Create(Aluno aluno);
    IEnumerable<Aluno> Read();
    IEnumerable<Aluno> Read(Guid id);
    void Update(Aluno aluno, Guid id);
    void Delete(Guid id);
}