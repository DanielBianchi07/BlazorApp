using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface IQuestaoSqlRepository
{
    void Create(Questao questao);
    IEnumerable<Questao> Read();
    Questao Read(Guid id);
    void Update(Questao questao, Guid id);
    void Delete(Guid id);
}