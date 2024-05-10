using BlazorApp.Api.Models;

namespace BlazorApp.Api.Repositories.Interface;

public interface ICertificadoSqlRepository
{
    void Create(Certificado certificado);
    IEnumerable<Certificado> Read();
    IEnumerable<Certificado> Read(Guid id);
    void Update(Certificado certificado, Guid id);
    void Delete(Guid id);
}