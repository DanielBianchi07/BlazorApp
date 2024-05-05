using BlazorApp.Api.Models;
// model = CadernoResposta
// variavel model = cadernoResposta

public interface ICadernoRespostaRepository
{
    void Create(CadernoResposta cadernoResposta);
    IEnumerable<CadernoResposta> Read();
    void Update(CadernoResposta cadernoResposta, Guid id);
    void Delete(Guid id);
}