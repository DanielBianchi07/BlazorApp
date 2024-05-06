using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface IEnderecoEmpresaRepository
{
    void Create(EnderecoEmpresa enderecoEmpresa);
    IEnumerable<EnderecoEmpresa> Read();
    void Update(EnderecoEmpresa enderecoEmpresa, Guid id);
    void Delete(Guid id);
}