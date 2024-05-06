using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface IUsuarioRepository
{
    void Create(Usuario usuario);
    IEnumerable<Usuario> Read();
    void Update(Usuario usuario, Guid id);
    void Delete(Guid id);
}