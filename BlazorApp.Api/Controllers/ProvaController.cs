using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;

namespace BlazorApp.Api.Controllers;

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

    [HttpPost]
    public ActionResult ProvaCreate(Prova provaModel)
    {
        _provaRepository.Create(provaModel);
        return Created();
    }


    [HttpPut("{id}")]
    public ActionResult ProvaUpdate(Prova provaModel, Guid id) 
    {
        _provaRepository.Update(provaModel, id);
        return Ok();
    }


    [HttpDelete("{id}")]
    public ActionResult<Prova> ProvaDelete(Guid id)
    {
        _provaRepository.Delete(id);
        return Ok();
    }
}