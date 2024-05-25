using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface IAlunoEmpresaSqlRepository
{
    void Create(AlunoEmpresa alunoEmpresa);
    IEnumerable<AlunoEmpresa> Read();
    AlunoEmpresa Read(Guid aluno_id, Guid empresa_id);
    void Update(AlunoEmpresa alunoEmpresa, Guid aluno_id, Guid empresa_id);
    void Delete(Guid aluno_id, Guid empresa_id);
}