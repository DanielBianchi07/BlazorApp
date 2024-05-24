using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlunoEmpresaController : ControllerBase
{
    private readonly IAlunoEmpresaSqlRepository _alunoEmpresaRepository;

    public AlunoEmpresaController(IAlunoEmpresaSqlRepository alunoEmpresaRepository)
    {
        _alunoEmpresaRepository = alunoEmpresaRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<AlunoEmpresa>> AlunoEmpresaRead()
    {
        IEnumerable<AlunoEmpresa> alunoEmpresas = _alunoEmpresaRepository.Read();
        return Ok(alunoEmpresas);
    }

    [HttpGet("{alunoId}/{empresaId}")]
    public ActionResult<IEnumerable<AlunoEmpresa>> AlunoEmpresaReadId(Guid alunoId, Guid empresaId)
    {
        IEnumerable<AlunoEmpresa> alunoEmpresas = _alunoEmpresaRepository.Read(alunoId, empresaId);
        return Ok(alunoEmpresas);
    }

    [HttpPost]
    public ActionResult AlunoEmpresaCreate(AlunoEmpresa alunoEmpresaModel)
    {
        _alunoEmpresaRepository.Create(alunoEmpresaModel);
        return Created();
    }


    [HttpPut("{alunoId}/{empresaId}")]
    public ActionResult AlunoEmpresaUpdate(AlunoEmpresa alunoEmpresaModel, Guid alunoId, Guid empresaId) 
    {
        _alunoEmpresaRepository.Update(alunoEmpresaModel, alunoId, empresaId);
        return Ok();
    }


    [HttpDelete("{alunoId}/{empresaId}")]
    public ActionResult<AlunoEmpresa> AlunoEmpresaDelete(Guid alunoId, Guid empresaId)
    {
        _alunoEmpresaRepository.Delete(alunoId, empresaId);
        return Ok();
    }
}