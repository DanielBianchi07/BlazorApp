using BlazorApp.Api.Models;
// model = CursoConteudo
// variavel model = cursoConteudo

public interface ICursoConteudoRepository
{
    void Create(CursoConteudo cursoConteudo);
    IEnumerable<CursoConteudo> Read();
    void Update(CursoConteudo cursoConteudo, Guid id);
    void Delete(Guid id);
}