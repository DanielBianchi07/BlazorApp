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

    [HttpGet("{idTreinamento}/{idAluno}")]
    public ActionResult<IEnumerable<AlunoTreinamento>> AlunoTreinamentoReadId(Guid idTreinamento, Guid idAluno)
    {
        IEnumerable<AlunoTreinamento> alunoTreinamentos = _alunoTreinamentoRepository.Read(idTreinamento, idAluno);
        return Ok(alunoTreinamentos);
    }

    [HttpPost]
    public ActionResult AlunoTreinamentoCreate(AlunoTreinamento alunoTreinamentoModel)
    {
        _alunoTreinamentoRepository.Create(alunoTreinamentoModel);
        return Created();
    }


    [HttpPut("{idTreinamento}/{idAluno}")]
    public ActionResult AlunoTreinamentoUpdate(AlunoTreinamento alunoTreinamentoModel, Guid idTreinamento, Guid idAluno) 
    {
        _alunoTreinamentoRepository.Update(alunoTreinamentoModel, idTreinamento, idAluno);
        return Ok();
    }


    [HttpDelete("{idTreinamento}/{idAluno}")]
    public ActionResult<AlunoTreinamento> AlunoTreinamentoDelete(Guid idTreinamento, Guid idAluno)
    {
        _alunoTreinamentoRepository.Delete(idTreinamento, idAluno);
        return Ok();
    }
}