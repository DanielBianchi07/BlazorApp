using BlazorApp.Api.Models;
// model = InstrutorTreinamento
// variavel model = instrutorTreinamento

public interface IInstrutorTreinamentoRepository
{
    void Create(InstrutorTreinamento instrutorTreinamento);
    IEnumerable<InstrutorTreinamento> Read();
    void Update(InstrutorTreinamento instrutorTreinamento, Guid id);
    void Delete(Guid id);
}