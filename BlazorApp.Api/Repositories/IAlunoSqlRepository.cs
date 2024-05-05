using BlazorApp.Api.Models;
// model = Aluno
// variavel model = aluno

public interface IAlunoRepository
{
    void Create(Aluno aluno);
    IEnumerable<Aluno> Read();
    void Update(Aluno aluno, Guid id);
    void Delete(Guid id);
}