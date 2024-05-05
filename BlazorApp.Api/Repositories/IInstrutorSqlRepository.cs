using BlazorApp.Api.Models;
// model = Instrutor
// variavel model = instrutor

public interface IInstrutorRepository
{
    void Create(Instrutor instrutor);
    IEnumerable<Instrutor> Read();
    void Update(Instrutor instrutor, Guid id);
    void Delete(Guid id);
}