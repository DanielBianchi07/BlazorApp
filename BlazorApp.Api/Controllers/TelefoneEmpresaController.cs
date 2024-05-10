using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TelefoneEmpresaController : ControllerBase
{
    private readonly ITelefoneEmpresaSqlRepository _telefoneEmpresaRepository;

    public TelefoneEmpresaController(ITelefoneEmpresaSqlRepository telefoneEmpresaRepository)
    {
        _telefoneEmpresaRepository = telefoneEmpresaRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<TelefoneEmpresa>> TelefoneEmpresaRead(Guid idEmpresa)
    {
        IEnumerable<TelefoneEmpresa> telefoneEmpresas = _telefoneEmpresaRepository.Read(idEmpresa);
        return Ok(telefoneEmpresas);
    }

    [HttpPost]
    public ActionResult TelefoneEmpresaCreate(TelefoneEmpresa telefoneEmpresaModel, Guid id)
    {
        _telefoneEmpresaRepository.Create(telefoneEmpresaModel, id);
        return Created();
    }


    [HttpPut("{id}")]
    public ActionResult TelefoneEmpresaUpdate(TelefoneEmpresa telefoneEmpresaModel, Guid idEmpresa, Guid idTelefone) 
    {
        _telefoneEmpresaRepository.Update(telefoneEmpresaModel, idEmpresa, idTelefone);
        return Ok();
    }


    [HttpDelete("{id}")]
    public ActionResult<TelefoneEmpresa> TelefoneEmpresaDelete(Guid idEmpresa, Guid idTelefone)
    {
        _telefoneEmpresaRepository.Delete(idEmpresa, idTelefone);
        return Ok();
    }
}