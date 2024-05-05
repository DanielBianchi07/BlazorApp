using BlazorApp.Api.Models;
// model = Pessoa
// variavel model = pessoa

public interface IPessoaRepository
{
    void Create(Pessoa pessoa);
    IEnumerable<Pessoa> Read();
    void Update(Pessoa pessoa, Guid id);
    void Delete(Guid id);
}