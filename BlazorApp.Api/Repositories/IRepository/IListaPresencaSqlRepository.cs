using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface IListaPresencaRepository
{
    void Create(ListaPresenca listaPresenca);
    IEnumerable<ListaPresenca> Read();
    void Update(ListaPresenca listaPresenca, Guid id);
    void Delete(Guid id);
}