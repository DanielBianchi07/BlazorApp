using Microsoft.AspNetCore.Mvc;
using BlazorSystem.Api.Models;

namespace BlazorSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CidadeController : ControllerBase
{
    private readonly ICidadeRepository _cidadeRepository;

    public CidadeController(ICidadeRepository cidadeRepository)
    {
        _cidadeRepository = cidadeRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<Cidade>> CidadeRead()
    {
        IEnumerable<Cidade> cidades = _cidadeRepository.Read();
        return Ok(cidades);
    }

    [HttpPost]
    public ActionResult CidadeCreate(Cidade cidadeModel)
    {
        _cidadeRepository.Create(cidadeModel);
        return RedirectToAction("Read");
    }


    [HttpPut("{id}")]
    public ActionResult CidadeUpdate(Cidade cidadeModel, Guid id) 
    {
        _cidadeRepository.Update(cidadeModel, id);
        return RedirectToAction("Read");
    }


    [HttpDelete("{id}")]
    public ActionResult<Cidade> CidadeDelete(Guid id)
    {
        _cidadeRepository.Delete(id);
        return RedirectToAction("Read");
    }
}