using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface IInstrutorTreinamentoSqlRepository
{
    void Create(InstrutorTreinamento instrutorTreinamento);
    IEnumerable<InstrutorTreinamento> Read();
    InstrutorTreinamento Read(Guid idPessoa, Guid idTreinamento);
    void Update(InstrutorTreinamento instrutorTreinamento, Guid idPessoa, Guid idTreinamento);
    void Delete(Guid idPessoa, Guid idTreinamento);
}