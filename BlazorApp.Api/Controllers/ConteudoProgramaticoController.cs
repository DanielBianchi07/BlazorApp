using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConteudoProgramaticoController : ControllerBase
{
    private readonly IConteudoProgramaticoSqlRepository _conteudoProgramaticoRepository;

    public ConteudoProgramaticoController(IConteudoProgramaticoSqlRepository conteudoProgramaticoRepository)
    {
        _conteudoProgramaticoRepository = conteudoProgramaticoRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<ConteudoProgramatico>> ConteudoProgramaticoRead()
    {
        IEnumerable<ConteudoProgramatico> conteudoProgramaticos = _conteudoProgramaticoRepository.Read();
        return Ok(conteudoProgramaticos);
    }

    [HttpGet("{id}")]
    public ActionResult<ConteudoProgramatico> ConteudoProgramaticoReadId(Guid id)
    {
        ConteudoProgramatico conteudoProgramatico = _conteudoProgramaticoRepository.Read(id);
        return Ok(conteudoProgramatico);
    }

    [HttpPost]
    public ActionResult ConteudoProgramaticoCreate(ConteudoProgramatico conteudoProgramaticoModel)
    {
        _conteudoProgramaticoRepository.Create(conteudoProgramaticoModel);
        return Created();
    }


    [HttpPut("{id}")]
    public ActionResult ConteudoProgramaticoUpdate(ConteudoProgramatico conteudoProgramaticoModel, Guid id) 
    {
        _conteudoProgramaticoRepository.Update(conteudoProgramaticoModel, id);
        return Ok();
    }


    [HttpDelete("{id}")]
    public ActionResult<ConteudoProgramatico> ConteudoProgramaticoDelete(Guid id)
    {
        _conteudoProgramaticoRepository.Delete(id);
        return Ok();
    }
}