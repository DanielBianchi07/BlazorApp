using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface ICadernoRespostaSqlRepository
{
    void Create(CadernoResposta cadernoResposta);
    IEnumerable<CadernoResposta> Read();
    void Update(CadernoResposta cadernoResposta, Guid id);
    void Delete(Guid id);
}