using BlazorApp.Api.Models;
// model = Usuario
// variavel model = usuario

public interface IUsuarioRepository
{
    void Create(Usuario usuario);
    IEnumerable<Usuario> Read();
    void Update(Usuario usuario, Guid id);
    void Delete(Guid id);
}