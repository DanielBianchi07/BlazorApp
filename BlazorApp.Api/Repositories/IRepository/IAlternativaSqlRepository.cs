using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface IAlternativaSqlRepository
{
    void Create(Alternativa alternativa);
    IEnumerable<Alternativa> Read();
    void Update(Alternativa alternativa);
    void Delete(Guid id);
}