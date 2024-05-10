using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface IProvaSqlRepository
{
    void Create(Prova prova);
    IEnumerable<Prova> Read();
    IEnumerable<Prova> Read(Guid id);
    void Update(Prova prova, Guid id);
    void Delete(Guid id);
}