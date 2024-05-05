using BlazorApp.Api.Models;
// model = EnderecoEmpresa
// variavel model = enderecoEmpresa

public interface IEnderecoEmpresaRepository
{
    void Create(EnderecoEmpresa enderecoEmpresa);
    IEnumerable<EnderecoEmpresa> Read();
    void Update(EnderecoEmpresa enderecoEmpresa, Guid id);
    void Delete(Guid id);
}