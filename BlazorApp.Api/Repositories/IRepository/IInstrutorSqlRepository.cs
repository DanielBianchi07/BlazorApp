using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface IInstrutorSqlRepository
{
    void Create(Instrutor instrutor);
    IEnumerable<Instrutor> Read();
    void Update(Instrutor instrutor, Guid id);
    void Delete(Guid id);
}