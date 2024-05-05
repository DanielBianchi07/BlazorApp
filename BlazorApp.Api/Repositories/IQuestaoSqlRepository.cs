using BlazorApp.Api.Models;
// model = Questao
// variavel model = questao

public interface IQuestaoRepository
{
    void Create(Questao questao);
    IEnumerable<Questao> Read();
    void Update(Questao questao, Guid id);
    void Delete(Guid id);
}