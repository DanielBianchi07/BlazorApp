using BlazorApp.Api.Models;
// model = Certificado
// variavel model = certificado

public interface ICertificadoRepository
{
    void Create(Certificado certificado);
    IEnumerable<Certificado> Read();
    void Update(Certificado certificado, Guid id);
    void Delete(Guid id);
}