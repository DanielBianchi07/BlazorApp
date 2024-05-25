using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface IAlunoTreinamentoSqlRepository
{
    void Create(AlunoTreinamento alunoTreinamento);
    IEnumerable<AlunoTreinamento> Read();
    AlunoTreinamento Read(Guid idTreinamento, Guid idAluno);
    void Update(AlunoTreinamento alunoTreinamento, Guid idTreinamento, Guid idAluno);
    void Delete(Guid idTreinamento, Guid idAluno);
}