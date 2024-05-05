using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;

namespace BlazorSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProvaController : ControllerBase
{
    private readonly IProvaRepository _provaRepository;

    public ProvaController(IProvaRepository provaRepository)
    {
        _provaRepository = provaRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<Prova>> ProvaRead()
    {
        IEnumerable<Prova> provas = _provaRepository.Read();
        return Ok(provas);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Prova>> ProvaReadId(Guid id)
    {
        IEnumerable<Prova> provas = _provaRepository.Read(id);
        return Ok(provas);
    }

    [HttpPost]
    public ActionResult ProvaCreate(Prova provaModel)
    {
        _provaRepository.Create(provaModel);
        return RedirectToAction("Read");
    }


    [HttpPut("{id}")]
    public ActionResult ProvaUpdate(Prova provaModel, Guid id) 
    {
        _provaRepository.Update(provaModel, id);
        return RedirectToAction("Read");
    }


    [HttpDelete("{id}")]
    public ActionResult<Prova> ProvaDelete(Guid id)
    {
        _provaRepository.Delete(id);
        return RedirectToAction("Read");
    }
}