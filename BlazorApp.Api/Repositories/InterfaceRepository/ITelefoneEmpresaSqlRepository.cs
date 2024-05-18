using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface ITelefoneEmpresaSqlRepository
{
    void Create(TelefoneEmpresa telefoneEmpresa, Guid idEmpresa);
    IEnumerable<TelefoneEmpresa> Read();
    IEnumerable<TelefoneEmpresa> Read(Guid idEmpresa, Guid idTelefone);
    void Update(TelefoneEmpresa telefoneEmpresa, Guid idEmpresa, Guid idTelefone);
    void Delete(Guid idEmpresa, Guid idTelefone);
}