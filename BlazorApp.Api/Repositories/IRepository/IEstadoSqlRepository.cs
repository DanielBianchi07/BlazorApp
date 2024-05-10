using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface IEstadoSqlRepository
{
    void Create(Estado estado);
    IEnumerable<Estado> Read();
    IEnumerable<Estado> Read(Guid id);
    void Update(Estado estado, Guid id);
    void Delete(Guid id);
}