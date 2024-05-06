using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;

namespace BlazorApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InstrutorTreinamentoController : ControllerBase
{
    private readonly IInstrutorTreinamentoRepository _instrutorTreinamentoRepository;

    public InstrutorTreinamentoController(IInstrutorTreinamentoRepository instrutorTreinamentoRepository)
    {
        _instrutorTreinamentoRepository = instrutorTreinamentoRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<InstrutorTreinamento>> InstrutorTreinamentoRead()
    {
        IEnumerable<InstrutorTreinamento> instrutorTreinamentos = _instrutorTreinamentoRepository.Read();
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