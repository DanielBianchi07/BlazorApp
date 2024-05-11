using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface IUsuarioSqlRepository
{
    void Create(Usuario usuario, Guid IdPessoa);
    IEnumerable<Usuario> Read();
    IEnumerable<Usuario> Read(Guid id);
    void Update(Usuario usuario, Guid idPessoa);
    void Delete(Guid id);
}