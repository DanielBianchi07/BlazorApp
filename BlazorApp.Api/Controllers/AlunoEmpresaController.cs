using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;

namespace BlazorApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlunoEmpresaController : ControllerBase
{
    private readonly IAlunoEmpresaRepository _alunoEmpresaRepository;

    public AlunoEmpresaController(IAlunoEmpresaRepository alunoEmpresaRepository)
    {
        _alunoEmpresaRepository = alunoEmpresaRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<AlunoEmpresa>> AlunoEmpresaRead()
    {
        IEnumerable<AlunoEmpresa> alunoEmpresas = _alunoEmpresaRepository.Read();
        return Ok(alunoEmpresas);
    }

    [HttpPost]
    public ActionResult AlunoEmpresaCreate(AlunoEmpresa alunoEmpresaModel)
    {
        _alunoEmpresaRepository.Create(alunoEmpresaModel);
        return Created();
    }


    [HttpPut("{id}")]
    public ActionResult AlunoEmpresaUpdate(AlunoEmpresa alunoEmpresaModel, Guid id) 
    {
        _alunoEmpresaRepository.Update(alunoEmpresaModel, id);
        return Ok();
    }


    [HttpDelete("{id}")]
    public ActionResult<AlunoEmpresa> AlunoEmpresaDelete(Guid id)
    {
        _alunoEmpresaRepository.Delete(id);
        return Ok();
    }
}