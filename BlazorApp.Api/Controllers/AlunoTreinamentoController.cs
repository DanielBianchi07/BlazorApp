using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlunoTreinamentoController : ControllerBase
{
    private readonly IAlunoTreinamentoSqlRepository _alunoTreinamentoRepository;

    public AlunoTreinamentoController(IAlunoTreinamentoSqlRepository alunoTreinamentoRepository)
    {
        _alunoTreinamentoRepository = alunoTreinamentoRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<AlunoTreinamento>> AlunoTreinamentoRead()
    {
        IEnumerable<AlunoTreinamento> alunoTreinamentos = _alunoTreinamentoRepository.Read();
        return Ok(alunoTreinamentos);
    }

    [HttpGet]
    public ActionResult<IEnumerable<AlunoTreinamento>> AlunoTreinamentoReadId(Guid id)
    {
        IEnumerable<AlunoTreinamento> alunoTreinamentos = _alunoTreinamentoRepository.Read(id);
        return Ok(alunoTreinamentos);
    }

    [HttpPost]
    public ActionResult AlunoTreinamentoCreate(AlunoTreinamento alunoTreinamentoModel)
    {
        _alunoTreinamentoRepository.Create(alunoTreinamentoModel);
        return Created();
    }


    [HttpPut("{id}")]
    public ActionResult AlunoTreinamentoUpdate(AlunoTreinamento alunoTreinamentoModel, Guid id) 
    {
        _alunoTreinamentoRepository.Update(alunoTreinamentoModel, id);
        return Ok();
    }


    [HttpDelete("{id}")]
    public ActionResult<AlunoTreinamento> AlunoTreinamentoDelete(Guid id)
    {
        _alunoTreinamentoRepository.Delete(id);
        return Ok();
    }
}