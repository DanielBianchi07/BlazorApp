using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface IProvaQuestaoSqlRepository
{
    void Create(ProvaQuestao provaQuestao);
    IEnumerable<ProvaQuestao> Read();
    IEnumerable<ProvaQuestao> Read(Guid id);
    void Update(ProvaQuestao provaQuestao, Guid id);
    void Delete(Guid id);
}