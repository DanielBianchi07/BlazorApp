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
    public ActionResult<IEnumerable<TelefoneEmpresa>> TelefoneEmpresaRead()
    {
        IEnumerable<TelefoneEmpresa> telefoneEmpresas = _telefoneEmpresaRepository.Read();
        return Ok(telefoneEmpresas);
    }

    [HttpGet("{idEmpresa}")]
    public ActionResult<IEnumerable<TelefoneEmpresa>> TelefoneEmpresaReadId(Guid idEmpresa)
    {
        IEnumerable<TelefoneEmpresa> telefonesEmpresa = _telefoneEmpresaRepository.Read(idEmpresa);
        return Ok(telefonesEmpresa);
    }

    [HttpPost("{idEmpresa}")]
    public ActionResult TelefoneEmpresaCreate(TelefoneEmpresa telefoneEmpresaModel, Guid idEmpresa)
    {
        _telefoneEmpresaRepository.Create(telefoneEmpresaModel, idEmpresa);
        return Created();
    }


    [HttpPut("{idTelefone}")]
    public ActionResult TelefoneEmpresaUpdate(TelefoneEmpresa telefoneEmpresaModel,Guid idTelefone) 
    {
        _telefoneEmpresaRepository.Update(telefoneEmpresaModel, idTelefone);
        return Ok();
    }


    [HttpDelete("{idTelefone}")]
    public ActionResult<TelefoneEmpresa> TelefoneEmpresaDelete(Guid idTelefone)
    {
        _telefoneEmpresaRepository.Delete(idTelefone);
        return Ok();
    }
}