using BlazorApp.Api.Models;
// model = ListaPresenca
// variavel model = listaPresenca

public interface IListaPresencaRepository
{
    void Create(ListaPresenca listaPresenca);
    IEnumerable<ListaPresenca> Read();
    void Update(ListaPresenca listaPresenca, Guid id);
    void Delete(Guid id);
}