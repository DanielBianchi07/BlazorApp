using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface IQuestaoRepository
{
    void Create(Questao questao);
    IEnumerable<Questao> Read();
    void Update(Questao questao, Guid id);
    void Delete(Guid id);
}