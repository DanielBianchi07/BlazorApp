using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface IUsuarioSqlRepository
{
    void Create(Usuario usuario);
    IEnumerable<Usuario> Read();
    Usuario Read(Guid id);
    void Update(Usuario usuario, Guid id);
    void Delete(Guid id);

}