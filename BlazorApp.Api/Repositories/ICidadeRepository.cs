using BlazorApp.Api.Models;
// model = Cidade
// variavel model = Cidade

public interface ICidadeRepository
{
    void Create(Cidade cidade);
    IEnumerable<Cidade> Read();
    void Update(Cidade cidade, Guid id);
    void Delete(Guid id);
}