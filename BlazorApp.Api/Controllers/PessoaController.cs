using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;

namespace BlazorSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PessoaController : ControllerBase
{
    private readonly IPessoaRepository _pessoaRepository;

    public PessoaController(IPessoaRepository pessoaRepository)
    {
        _pessoaRepository = pessoaRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<Pessoa>> PessoaRead()
    {
        IEnumerable<Pessoa> pessoas = _pessoaRepository.Read();
        return Ok(pessoas);
    }

    [HttpPost]
    public ActionResult PessoaCreate(Pessoa pessoaModel)
    {
        _pessoaRepository.Create(pessoaModel);
        return RedirectToAction("Read");
    }


    [HttpPut("{id}")]
    public ActionResult PessoaUpdate(Pessoa pessoaModel, Guid id) 
    {
        _pessoaRepository.Update(pessoaModel, id);
        return RedirectToAction("Read");
    }


    [HttpDelete("{id}")]
    public ActionResult<Pessoa> PessoaDelete(Guid id)
    {
        _pessoaRepository.Delete(id);
        return RedirectToAction("Read");
    }
}