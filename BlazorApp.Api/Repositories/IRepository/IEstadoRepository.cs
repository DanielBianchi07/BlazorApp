using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface IEstadoRepository
{
    void Create(Estado estado);
    IEnumerable<Estado> Read();
    void Update(Estado estado, Guid id);
    void Delete(Guid id);
}