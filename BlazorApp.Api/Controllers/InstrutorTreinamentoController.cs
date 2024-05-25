using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InstrutorTreinamentoController : ControllerBase
{
    private readonly IInstrutorTreinamentoSqlRepository _instrutorTreinamentoRepository;

    public InstrutorTreinamentoController(IInstrutorTreinamentoSqlRepository instrutorTreinamentoRepository)
    {
        _instrutorTreinamentoRepository = instrutorTreinamentoRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<InstrutorTreinamento>> InstrutorTreinamentoRead()
    {
        IEnumerable<InstrutorTreinamento> instrutorTreinamentos = _instrutorTreinamentoRepository.Read();
        return Ok(instrutorTreinamentos);
    }

    [HttpGet("{idPessoa}/{idTreinamento}")]
    public ActionResult<InstrutorTreinamento> InstrutorTreinamentoReadId(Guid idPessoa, Guid idTreinamento)
    {
        InstrutorTreinamento instrutorTreinamento = _instrutorTreinamentoRepository.Read(idPessoa, idTreinamento);
        return Ok(instrutorTreinamento);
    }

    [HttpPost]
    public ActionResult InstrutorTreinamentoCreate(InstrutorTreinamento instrutorTreinamentoModel)
    {
        _instrutorTreinamentoRepository.Create(instrutorTreinamentoModel);
        return Created();
    }


    [HttpPut("{idPessoa}/{idTreinamento}")]
    public ActionResult InstrutorTreinamentoUpdate(InstrutorTreinamento instrutorTreinamentoModel, Guid idPessoa, Guid idTreinamento) 
    {
        _instrutorTreinamentoRepository.Update(instrutorTreinamentoModel, idPessoa, idTreinamento);
        return Ok();
    }


    [HttpDelete("{idPessoa}/{idTreinamento}")]
    public ActionResult<InstrutorTreinamento> InstrutorTreinamentoDelete(Guid idPessoa, Guid idTreinamento)
    {
        _instrutorTreinamentoRepository.Delete(idPessoa, idTreinamento);
        return Ok();
    }
}