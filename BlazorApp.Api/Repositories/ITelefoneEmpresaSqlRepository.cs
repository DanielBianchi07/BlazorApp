using BlazorApp.Api.Models;
// model = TelefoneEmpresa
// variavel model = telefoneEmpresa

public interface ITelefoneEmpresaRepository
{
    void Create(TelefoneEmpresa telefoneEmpresa, Guid id);
    //IEnumerable<TelefoneEmpresa> Read();
    void Update(TelefoneEmpresa telefoneEmpresa, Guid id);
    void Delete(Guid id);
}