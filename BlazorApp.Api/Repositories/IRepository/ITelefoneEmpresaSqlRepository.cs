using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface ITelefoneEmpresaRepository
{
    void Create(TelefoneEmpresa telefoneEmpresa, Guid id);
    //IEnumerable<TelefoneEmpresa> Read();
    void Update(TelefoneEmpresa telefoneEmpresa, Guid id);
    void Delete(Guid id);
}