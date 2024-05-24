using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface IEnderecoEmpresaSqlRepository
{
    void Create(EnderecoEmpresa enderecoEmpresa);
    IEnumerable<EnderecoEmpresa> Read();
    EnderecoEmpresa Read(Guid idEmpresa);
    void Update(EnderecoEmpresa enderecoEmpresa, Guid id);
    void Delete(Guid id);
}