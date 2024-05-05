using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;

namespace BlazorApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InstrutorController : ControllerBase
{
    private readonly IInstrutorRepository _instrutorRepository;

    public InstrutorController(IInstrutorRepository instrutorRepository)
    {
        _instrutorRepository = instrutorRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<Instrutor>> InstrutorRead()
    {
        IEnumerable<Instrutor> instrutores = _instrutorRepository.Read();
        return Ok(instrutores);
    }

    [HttpPost]
    public ActionResult InstrutorCreate(Instrutor instrutorModel)
    {
        _instrutorRepository.Create(instrutorModel);
        return Created();
    }


    [HttpPut("{id}")]
    public ActionResult InstrutorUpdate(Instrutor instrutorModel, Guid id) 
    {
        _instrutorRepository.Update(instrutorModel, id);
        return Ok();
    }


    [HttpDelete("{id}")]
    public ActionResult<Instrutor> InstrutorDelete(Guid id)
    {
        _instrutorRepository.Delete(id);
        return Ok();
    }
}