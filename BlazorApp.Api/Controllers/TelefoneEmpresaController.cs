using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;

namespace BlazorSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TelefoneEmpresaController : ControllerBase
{
    private readonly ITelefoneEmpresaRepository _telefoneEmpresaRepository;

    public TelefoneEmpresaController(ITelefoneEmpresaRepository telefoneEmpresaRepository)
    {
        _telefoneEmpresaRepository = telefoneEmpresaRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<TelefoneEmpresa>> TelefoneEmpresaRead()
    {
        IEnumerable<TelefoneEmpresa> telefoneEmpresas = _telefoneEmpresaRepository.Read();
        return Ok(telefoneEmpresas);
    }

    [HttpPost]
    public ActionResult TelefoneEmpresaCreate(TelefoneEmpresa telefoneEmpresaModel)
    {
        _telefoneEmpresaRepository.Create(telefoneEmpresaModel);
        return RedirectToAction("Read");
    }


    [HttpPut("{id}")]
    public ActionResult TelefoneEmpresaUpdate(TelefoneEmpresa telefoneEmpresaModel, Guid id) 
    {
        _telefoneEmpresaRepository.Update(telefoneEmpresaModel, id);
        return RedirectToAction("Read");
    }


    [HttpDelete("{id}")]
    public ActionResult<TelefoneEmpresa> TelefoneEmpresaDelete(Guid id)
    {
        _telefoneEmpresaRepository.Delete(id);
        return RedirectToAction("Read");
    }
}