using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TreinamentoController : ControllerBase
{
    private readonly ITreinamentoSqlRepository _treinamentoRepository;

    public TreinamentoController(ITreinamentoSqlRepository treinamentoRepository)
    {
        _treinamentoRepository = treinamentoRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<Treinamento>> TreinamentoRead()
    {
        IEnumerable<Treinamento> treinamentos = _treinamentoRepository.Read();
        return Ok(treinamentos);
    }

    [HttpGet("{id}")]
    public ActionResult<Treinamento> TreinamentoReadId(Guid id)
    {
        Treinamento treinamento = _treinamentoRepository.Read(id);
        return Ok(treinamento);
    }

    [HttpPost]
    public ActionResult TreinamentoCreate(Treinamento treinamentoModel)
    {
        _treinamentoRepository.Create(treinamentoModel);
        return Created();
    }


    [HttpPut("{id}")]
    public ActionResult TreinamentoUpdate(Treinamento treinamentoModel, Guid id) 
    {
        _treinamentoRepository.Update(treinamentoModel, id);
        return Ok();
    }


    [HttpDelete("{id}")]
    public ActionResult<Treinamento> TreinamentoDelete(Guid id)
    {
        _treinamentoRepository.Delete(id);
        return Ok();
    }
}