using BlazorApp.Api.Models;
// model = Alternativa
// variavel model = alternativa

public interface IAlternativaRepository
{
    void Create(Alternativa alternativa);
    IEnumerable<Alternativa> Read();
    void Update(Alternativa alternativa, Guid id);
    void Delete(Guid id);
}