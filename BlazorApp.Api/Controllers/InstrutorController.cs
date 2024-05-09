using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InstrutorController : ControllerBase
{
    private readonly IInstrutorSqlRepository _instrutorRepository;

    public InstrutorController(IInstrutorSqlRepository instrutorRepository)
    {
        _instrutorRepository = instrutorRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<Instrutor>> InstrutorRead()
    {
        IEnumerable<Instrutor> instrutores = _instrutorRepository.Read();
        return Ok(instrutores);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Instrutor>> InstrutorReadId(Guid id)
    {
        IEnumerable<Instrutor> instrutores = _instrutorRepository.Read(id);
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