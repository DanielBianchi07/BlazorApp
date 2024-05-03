using BlazorApp.Api.Models;

public interface IEmpresaRepository
{
    void Create(Empresa empresa);
    IEnumerable<Empresa> Read();
    void Update(Empresa empresa, Guid id);
    void Delete(Guid id);
}