using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface IInstrutorRepository
{
    void Create(Instrutor instrutor, Guid id);
    IEnumerable<Instrutor> Read();
    void Update(Instrutor instrutor, Guid id);
    void Delete(Guid id);
}