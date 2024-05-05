using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;

namespace BlazorApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EstadoController : ControllerBase
{
    private readonly IEstadoRepository _estadoRepository;

    public EstadoController(IEstadoRepository estadoRepository)
    {
        _estadoRepository = estadoRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<Estado>> EstadoRead()
    {
        IEnumerable<Estado> estados = _estadoRepository.Read();
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