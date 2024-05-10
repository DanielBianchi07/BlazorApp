using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EstadoController : ControllerBase
{
    private readonly IEstadoSqlRepository _estadoRepository;

    public EstadoController(IEstadoSqlRepository estadoRepository)
    {
        _estadoRepository = estadoRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<Estado>> EstadoRead()
    {
        IEnumerable<Estado> estados = _estadoRepository.Read();
        return Ok(estados);
    }

    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Estado>> EstadoReadId(Guid id)
    {
        IEnumerable<Estado> estados = _estadoRepository.Read(id);
        return Ok(estados);
    }

    [HttpPost]
    public ActionResult EstadoCreate(Estado estadoModel)
    {
        _estadoRepository.Create(estadoModel);
        return Created();
    }


    [HttpPut("{id}")]
    public ActionResult EstadoUpdate(Estado estadoModel, Guid id) 
    {
        _estadoRepository.Update(estadoModel, id);
        return Ok();
    }


    [HttpDelete("{id}")]
    public ActionResult<Estado> EstadoDelete(Guid id)
    {
        _estadoRepository.Delete(id);
        return Ok();
    }
}