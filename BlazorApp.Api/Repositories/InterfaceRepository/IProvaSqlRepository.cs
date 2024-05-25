using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface IProvaSqlRepository
{
    void Create(Prova prova);
    IEnumerable<Prova> Read();
    Prova Read(Guid idProva, Guid idPessoa);
    void Update(Prova prova, Guid idProva, Guid idPessoa);
    void Delete(Guid idProva, Guid idPessoa);
}