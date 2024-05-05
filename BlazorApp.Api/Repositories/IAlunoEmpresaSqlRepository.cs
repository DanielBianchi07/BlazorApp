using BlazorApp.Api.Models;
// model = AlunoEmpresa
// variavel model = alunoEmpresa

public interface IAlunoEmpresaRepository
{
    void Create(AlunoEmpresa alunoEmpresa);
    IEnumerable<AlunoEmpresa> Read();
    void Update(AlunoEmpresa alunoEmpresa, Guid id);
    void Delete(Guid id);
}