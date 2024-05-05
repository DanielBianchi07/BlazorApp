using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;

namespace BlazorSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TreinamentoController : ControllerBase
{
    private readonly ITreinamentoRepository _treinamentoRepository;

    public TreinamentoController(ITreinamentoRepository treinamentoRepository)
    {
        _treinamentoRepository = treinamentoRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<Treinamento>> TreinamentoRead()
    {
        IEnumerable<Treinamento> treinamentos = _treinamentoRepository.Read();
        return Ok(treinamentos);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Treinamento>> TreinamentoReadId(Guid id)
    {
        IEnumerable<Treinamento> treinamentos = _treinamentoRepository.Read(id);
        return Ok(treinamentos);
    }

    [HttpPost]
    public ActionResult TreinamentoCreate(Treinamento treinamentoModel)
    {
        _treinamentoRepository.Create(treinamentoModel);
        return RedirectToAction("Read");
    }


    [HttpPut("{id}")]
    public ActionResult TreinamentoUpdate(Treinamento treinamentoModel, Guid id) 
    {
        _treinamentoRepository.Update(treinamentoModel, id);
        return RedirectToAction("Read");
    }


    [HttpDelete("{id}")]
    public ActionResult<Treinamento> TreinamentoDelete(Guid id)
    {
        _treinamentoRepository.Delete(id);
        return RedirectToAction("Read");
    }
}