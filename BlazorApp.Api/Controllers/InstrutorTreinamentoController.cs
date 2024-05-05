using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;

namespace BlazorSystem.Api.Controllers;

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
        return RedirectToAction("Read");
    }


    [HttpPut("{id}")]
    public ActionResult InstrutorTreinamentoUpdate(InstrutorTreinamento instrutorTreinamentoModel, Guid id) 
    {
        _instrutorTreinamentoRepository.Update(instrutorTreinamentoModel, id);
        return RedirectToAction("Read");
    }


    [HttpDelete("{id}")]
    public ActionResult<InstrutorTreinamento> InstrutorTreinamentoDelete(Guid id)
    {
        _instrutorTreinamentoRepository.Delete(id);
        return RedirectToAction("Read");
    }
}