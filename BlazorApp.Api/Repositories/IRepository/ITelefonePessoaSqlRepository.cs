using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface ITelefonePessoaRepository
{
    void Create(TelefonePessoa telefonePessoa);
    IEnumerable<TelefonePessoa> Read();
    void Update(TelefonePessoa telefonePessoa, Guid id);
    void Delete(Guid id);
}