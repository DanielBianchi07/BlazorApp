using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface ICursoConteudoRepository
{
    void Create(CursoConteudo cursoConteudo);
    IEnumerable<CursoConteudo> Read();
    void Update(CursoConteudo cursoConteudo, Guid id);
    void Delete(Guid id);
}