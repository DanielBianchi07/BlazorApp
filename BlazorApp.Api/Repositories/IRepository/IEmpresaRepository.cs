using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface IEmpresaRepository
{
    void Create(Empresa empresa);
    IEnumerable<Empresa> Read();
    void Update(Empresa empresa, Guid id);
    void Delete(Guid id);
}