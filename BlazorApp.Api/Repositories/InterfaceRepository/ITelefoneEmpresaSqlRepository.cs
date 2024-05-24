using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface ITelefoneEmpresaSqlRepository
{
    void Create(TelefoneEmpresa telefoneEmpresa, Guid idEmpresa);
    IEnumerable<TelefoneEmpresa> Read();
    IEnumerable<TelefoneEmpresa> Read(Guid idEmpresa);
    void Update(TelefoneEmpresa telefoneEmpresa, Guid idTelefone);
    void Delete(Guid idTelefone);
}