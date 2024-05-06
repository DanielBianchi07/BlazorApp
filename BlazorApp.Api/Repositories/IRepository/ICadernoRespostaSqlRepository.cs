using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface ICadernoRespostaRepository
{
    void Create(CadernoResposta cadernoResposta);
    IEnumerable<CadernoResposta> Read();
    void Update(CadernoResposta cadernoResposta, Guid id);
    void Delete(Guid id);
}