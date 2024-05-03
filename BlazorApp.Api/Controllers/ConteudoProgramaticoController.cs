using Microsoft.AspNetCore.Mvc;
using BlazorSystem.Api.Models;

namespace BlazorSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConteudoProgramaticoController : ControllerBase
{
    private readonly IConteudoProgramaticoRepository _conteudoProgramaticoRepository;

    public ConteudoProgramaticoController(IConteudoProgramaticoRepository conteudoProgramaticoRepository)
    {
        _conteudoProgramaticoRepository = conteudoProgramaticoRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<ConteudoProgramatico>> ConteudoProgramaticoRead()
    {
        IEnumerable<ConteudoProgramatico> conteudoProgramaticos = _conteudoProgramaticoRepository.Read();
        return Ok(conteudoProgramaticos);
    }

    [HttpPost]
    public ActionResult ConteudoProgramaticoCreate(ConteudoProgramatico conteudoProgramaticoModel)
    {
        _conteudoProgramaticoRepository.Create(conteudoProgramaticoModel);
        return RedirectToAction("Read");
    }


    [HttpPut("{id}")]
    public ActionResult ConteudoProgramaticoUpdate(ConteudoProgramatico conteudoProgramaticoModel, Guid id) 
    {
        _conteudoProgramaticoRepository.Update(conteudoProgramaticoModel, id);
        return RedirectToAction("Read");
    }


    [HttpDelete("{id}")]
    public ActionResult<ConteudoProgramatico> ConteudoProgramaticoDelete(Guid id)
    {
        _conteudoProgramaticoRepository.Delete(id);
        return RedirectToAction("Read");
    }
}