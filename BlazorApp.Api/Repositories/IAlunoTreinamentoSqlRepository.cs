using BlazorApp.Api.Models;
// model = AlunoTreinamento
// variavel model = alunoTreinamento

public interface IAlunoTreinamentoRepository
{
    void Create(AlunoTreinamento alunoTreinamento);
    IEnumerable<AlunoTreinamento> Read();
    void Update(AlunoTreinamento alunoTreinamento, Guid id);
    void Delete(Guid id);
}