using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface ITelefonePessoaSqlRepository
{
    void Create(TelefonePessoa telefonePessoa);
    IEnumerable<TelefonePessoa> Read();
    TelefonePessoa Read(Guid idPessoa, Guid idTelefone);
    void Update(TelefonePessoa telefonePessoa, Guid idPessoa, Guid idTelefone);
    void Delete(Guid idPessoa, Guid idTelefone);
}