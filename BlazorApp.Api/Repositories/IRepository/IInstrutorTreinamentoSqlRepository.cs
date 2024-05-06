using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface IInstrutorTreinamentoRepository
{
    void Create(InstrutorTreinamento instrutorTreinamento);
    IEnumerable<InstrutorTreinamento> Read();
    void Update(InstrutorTreinamento instrutorTreinamento, Guid id);
    void Delete(Guid id);
}