using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface ICidadeSqlRepository
{
    void Create(Cidade cidade);
    IEnumerable<Cidade> Read();
    void Update(Cidade cidade, Guid id);
    void Delete(Guid id);
}