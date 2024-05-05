using BlazorApp.Api.Models;
// model = ProvaQuestao
// variavel model = provaQuestao

public interface IProvaQuestaoRepository
{
    void Create(ProvaQuestao provaQuestao);
    IEnumerable<ProvaQuestao> Read();
    void Update(ProvaQuestao provaQuestao, Guid id);
    void Delete(Guid id);
}