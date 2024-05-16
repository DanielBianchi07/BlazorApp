using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface IEmpresaSqlRepository
{
    Guid Create(Empresa empresa);
    IEnumerable<Empresa> Read();
    IEnumerable<Empresa> Read(Guid id);
    void Update(Empresa empresa, Guid id);
    void Delete(Guid id);
}