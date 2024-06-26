using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface IPessoaSqlRepository
{
    void Create(Pessoa pessoa);
    IEnumerable<Pessoa> Read();
    Pessoa Read(Guid id);
    void Update(Pessoa pessoa, Guid id);
    void Delete(Guid id);
}