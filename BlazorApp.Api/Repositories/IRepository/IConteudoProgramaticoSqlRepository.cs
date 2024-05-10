using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface IConteudoProgramaticoSqlRepository
{
    void Create(ConteudoProgramatico conteudoProgramatico);
    IEnumerable<ConteudoProgramatico> Read();
    IEnumerable<ConteudoProgramatico> Read(Guid id);
    void Update(ConteudoProgramatico conteudoProgramatico, Guid id);
    void Delete(Guid id);
}