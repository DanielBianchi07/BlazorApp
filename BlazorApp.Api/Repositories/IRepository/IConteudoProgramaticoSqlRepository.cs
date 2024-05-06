using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface IConteudoProgramaticoRepository
{
    void Create(ConteudoProgramatico conteudoProgramatico);
    IEnumerable<ConteudoProgramatico> Read();
    void Update(ConteudoProgramatico conteudoProgramatico, Guid id);
    void Delete(Guid id);
}