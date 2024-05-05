using BlazorApp.Api.Models;
// model = TelefonePessoa
// variavel model = telefonePessoa

public interface ITelefonePessoaRepository
{
    void Create(TelefonePessoa telefonePessoa);
    IEnumerable<TelefonePessoa> Read();
    void Update(TelefonePessoa telefonePessoa, Guid id);
    void Delete(Guid id);
}