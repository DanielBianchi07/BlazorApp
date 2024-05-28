using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface IUsuarioSqlRepository
{
    void Create(Usuario usuario);
    IEnumerable<Usuario> Read();
    Usuario Read(Guid id);
    Usuario ReadNomeSenha(string nome, string senha);
    void Update(Usuario usuario, Guid id);
    void Delete(Guid id);

}