using Microsoft.AspNetCore.Mvc;
using BlazorSystem.Api.Models;

namespace BlazorSystem.Api.Controllers;

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
        return RedirectToAction("Read");
    }


    [HttpPut("{id}")]
    public ActionResult InstrutorUpdate(Instrutor instrutorModel, Guid id) 
    {
        _instrutorRepository.Update(instrutorModel, id);
        return RedirectToAction("Read");
    }


    [HttpDelete("{id}")]
    public ActionResult<Instrutor> InstrutorDelete(Guid id)
    {
        _instrutorRepository.Delete(id);
        return RedirectToAction("Read");
    }
}