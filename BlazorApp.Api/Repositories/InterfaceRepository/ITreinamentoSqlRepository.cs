using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface ITreinamentoSqlRepository
{
    void Create(Treinamento treinamento);
    IEnumerable<Treinamento> Read();
    IEnumerable<Treinamento> Read(Guid id);
    void Update(Treinamento treinamento, Guid id);
    void Delete(Guid id);
}