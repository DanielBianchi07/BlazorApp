using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface IAlternativaRepository
{
    void Create(Alternativa alternativa);
    IEnumerable<Alternativa> Read();
    void Update(Alternativa alternativa, Guid id);
    void Delete(Guid id);
}