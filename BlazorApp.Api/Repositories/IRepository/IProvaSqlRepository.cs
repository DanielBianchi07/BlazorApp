using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface IProvaRepository
{
    void Create(Prova prova);
    IEnumerable<Prova> Read();
    void Update(Prova prova, Guid id);
    void Delete(Guid id);
}