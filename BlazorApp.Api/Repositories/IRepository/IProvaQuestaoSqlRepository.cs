using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface IProvaQuestaoRepository
{
    void Create(ProvaQuestao provaQuestao);
    IEnumerable<ProvaQuestao> Read();
    void Update(ProvaQuestao provaQuestao, Guid id);
    void Delete(Guid id);
}