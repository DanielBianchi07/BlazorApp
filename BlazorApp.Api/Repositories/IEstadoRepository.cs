using BlazorApp.Api.Models;
// model = Estado
// variavel model = Estado

public interface IEstadoRepository
{
    void Create(Estado estado);
    IEnumerable<Estado> Read();
    void Update(Estado estado, Guid id);
    void Delete(Guid id);
}