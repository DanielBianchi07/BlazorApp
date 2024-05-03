using Microsoft.AspNetCore.Mvc;
using BlazorSystem.Api.Models;

namespace BlazorSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CertificadoController : ControllerBase
{
    private readonly ICertificadoRepository _certificadoRepository;

    public CertificadoController(ICertificadoRepository certificadoRepository)
    {
        _certificadoRepository = certificadoRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<Certificado>> CertificadoRead()
    {
        IEnumerable<Certificado> certificados = _certificadoRepository.Read();
        return Ok(certificados);
    }

    [HttpPost]
    public ActionResult CertificadoCreate(Certificado certificadoModel)
    {
        _certificadoRepository.Create(certificadoModel);
        return RedirectToAction("Read");
    }


    [HttpPut("{id}")]
    public ActionResult CertificadoUpdate(Certificado certificadoModel, Guid id) 
    {
        _certificadoRepository.Update(certificadoModel, id);
        return RedirectToAction("Read");
    }


    [HttpDelete("{id}")]
    public ActionResult<Certificado> CertificadoDelete(Guid id)
    {
        _certificadoRepository.Delete(id);
        return RedirectToAction("Read");
    }
}