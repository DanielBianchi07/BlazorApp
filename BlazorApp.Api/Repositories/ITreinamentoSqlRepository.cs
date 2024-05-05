using BlazorApp.Api.Models;
// model = Treinamento
// variavel model = treinamento

public interface ITreinamentoRepository
{
    void Create(Treinamento treinamento);
    IEnumerable<Treinamento> Read();
    void Update(Treinamento treinamento, Guid id);
    void Delete(Guid id);
}