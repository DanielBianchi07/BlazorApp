using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface IEstadoSqlRepository
{
    void Create(Estado estado);
    IEnumerable<Estado> Read();
    void Update(Estado estado, Guid id);
    void Delete(Guid id);
}