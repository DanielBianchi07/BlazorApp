using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface IProvaQuestaoSqlRepository
{
    void Create(ProvaQuestao provaQuestao);
    IEnumerable<ProvaQuestao> Read();
    ProvaQuestao Read(Guid idQuestao, Guid idProva);
    void Update(ProvaQuestao provaQuestao, Guid id);
    void Delete(Guid idQuestao, Guid idProva);
}