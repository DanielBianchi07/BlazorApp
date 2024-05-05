using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;

namespace BlazorSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlunoTreinamentoController : ControllerBase
{
    private readonly IAlunoTreinamentoRepository _alunoTreinamentoRepository;

    public AlunoTreinamentoController(IAlunoTreinamentoRepository alunoTreinamentoRepository)
    {
        _alunoTreinamentoRepository = alunoTreinamentoRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<AlunoTreinamento>> AlunoTreinamentoRead()
    {
        IEnumerable<AlunoTreinamento> alunoTreinamentos = _alunoTreinamentoRepository.Read();
        return Ok(alunoTreinamentos);
    }

    [HttpPost]
    public ActionResult AlunoTreinamentoCreate(AlunoTreinamento alunoTreinamentoModel)
    {
        _alunoTreinamentoRepository.Create(alunoTreinamentoModel);
        return RedirectToAction("Read");
    }


    [HttpPut("{id}")]
    public ActionResult AlunoTreinamentoUpdate(AlunoTreinamento alunoTreinamentoModel, Guid id) 
    {
        _alunoTreinamentoRepository.Update(alunoTreinamentoModel, id);
        return RedirectToAction("Read");
    }


    [HttpDelete("{id}")]
    public ActionResult<AlunoTreinamento> AlunoTreinamentoDelete(Guid id)
    {
        _alunoTreinamentoRepository.Delete(id);
        return RedirectToAction("Read");
    }
}