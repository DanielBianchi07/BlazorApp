using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface IAlunoTreinamentoSqlRepository
{
    void Create(AlunoTreinamento alunoTreinamento);
    IEnumerable<AlunoTreinamento> Read();
    void Update(AlunoTreinamento alunoTreinamento, Guid id);
    void Delete(Guid id);
}