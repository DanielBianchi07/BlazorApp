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

    [HttpGet]
    public ActionResult<IEnumerable<InstrutorTreinamento>> InstrutorTreinamentoReadId(Guid id)
    {
        IEnumerable<InstrutorTreinamento> instrutorTreinamentos = _instrutorTreinamentoRepository.Read(id);
        return Ok(instrutorTreinamentos);
    }

    [HttpPost]
    public ActionResult InstrutorTreinamentoCreate(InstrutorTreinamento instrutorTreinamentoModel)
    {
        _instrutorTreinamentoRepository.Create(instrutorTreinamentoModel);
        return Created();
    }


    [HttpPut("{id}")]
    public ActionResult InstrutorTreinamentoUpdate(InstrutorTreinamento instrutorTreinamentoModel, Guid id) 
    {
        _instrutorTreinamentoRepository.Update(instrutorTreinamentoModel, id);
        return Ok();
    }


    [HttpDelete("{id}")]
    public ActionResult<InstrutorTreinamento> InstrutorTreinamentoDelete(Guid id)
    {
        _instrutorTreinamentoRepository.Delete(id);
        return Ok();
    }
}