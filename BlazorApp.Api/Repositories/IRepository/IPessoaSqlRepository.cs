using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface IPessoaRepository
{
    void Create(Pessoa pessoa);
    IEnumerable<Pessoa> Read();
    void Update(Pessoa pessoa, Guid id);
    void Delete(Guid id);
}