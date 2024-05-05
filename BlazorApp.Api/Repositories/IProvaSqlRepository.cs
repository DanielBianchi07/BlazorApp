using BlazorApp.Api.Models;
// model = Prova
// variavel model = prova

public interface IProvaRepository
{
    void Create(Prova prova);
    IEnumerable<Prova> Read();
    void Update(Prova prova, Guid id);
    void Delete(Guid id);
}