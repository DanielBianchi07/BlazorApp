using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface IListaPresencaSqlRepository
{
    void Create(ListaPresenca listaPresenca);
    IEnumerable<ListaPresenca> Read();
    IEnumerable<ListaPresenca> Read(Guid id);
    void Update(ListaPresenca listaPresenca, Guid id);
    void Delete(Guid id);
}