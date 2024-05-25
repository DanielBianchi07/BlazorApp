using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CertificadoController : ControllerBase
{
    private readonly ICertificadoSqlRepository _certificadoRepository;

    public CertificadoController(ICertificadoSqlRepository certificadoRepository)
    {
        _certificadoRepository = certificadoRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<Certificado>> CertificadoRead()
    {
        IEnumerable<Certificado> certificados = _certificadoRepository.Read();
        return Ok(certificados);
    }

    [HttpGet("{id}")]
    public ActionResult<Certificado> CertificadoReadId(Guid id)
    {
        Certificado certificado = _certificadoRepository.Read(id);
        return Ok(certificado);
    }

    [HttpPost]
    public ActionResult CertificadoCreate(Certificado certificadoModel)
    {
        _certificadoRepository.Create(certificadoModel);
        return Created();
    }


    [HttpPut("{id}")]
    public ActionResult CertificadoUpdate(Certificado certificadoModel, Guid id) 
    {
        _certificadoRepository.Update(certificadoModel, id);
        return Ok();
    }


    [HttpDelete("{id}")]
    public ActionResult<Certificado> CertificadoDelete(Guid id)
    {
        _certificadoRepository.Delete(id);
        return Ok();
    }
}