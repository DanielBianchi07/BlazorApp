using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface ICertificadoRepository
{
    void Create(Certificado certificado);
    IEnumerable<Certificado> Read();
    void Update(Certificado certificado, Guid id);
    void Delete(Guid id);
}