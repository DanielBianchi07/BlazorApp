using BlazorApp.Api.Models;
// model = ConteudoProgramatico
// variavel model = conteudoProgramatico

public interface IConteudoProgramaticoRepository
{
    void Create(ConteudoProgramatico conteudoProgramatico);
    IEnumerable<ConteudoProgramatico> Read();
    void Update(ConteudoProgramatico conteudoProgramatico, Guid id);
    void Delete(Guid id);
}