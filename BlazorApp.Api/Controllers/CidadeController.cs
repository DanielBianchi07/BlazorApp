using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CidadeController : ControllerBase
{
    private readonly ICidadeSqlRepository _cidadeRepository;

    public CidadeController(ICidadeSqlRepository cidadeRepository)
    {
        _cidadeRepository = cidadeRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<Cidade>> CidadeRead()
    {
        IEnumerable<Cidade> cidades = _cidadeRepository.Read();
        return Ok(cidades);
    }

    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Cidade>> CidadeReadId(Guid id)
    {
        IEnumerable<Cidade> cidades = _cidadeRepository.Read(id);
        return Ok(cidades);
    }

    [HttpPost]
    public ActionResult CidadeCreate(Cidade cidadeModel)
    {
        _cidadeRepository.Create(cidadeModel);
        return Created();
    }


    [HttpPut("{id}")]
    public ActionResult CidadeUpdate(Cidade cidadeModel, Guid id) 
    {
        _cidadeRepository.Update(cidadeModel, id);
        return Ok();
    }


    [HttpDelete("{id}")]
    public ActionResult<Cidade> CidadeDelete(Guid id)
    {
        _cidadeRepository.Delete(id);
        return Ok();
    }
}