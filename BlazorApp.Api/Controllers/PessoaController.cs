using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PessoaController : ControllerBase
{
    private readonly IPessoaSqlRepository _pessoaRepository;

    public PessoaController(IPessoaSqlRepository pessoaRepository)
    {
        _pessoaRepository = pessoaRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<Pessoa>> PessoaRead()
    {
        IEnumerable<Pessoa> pessoas = _pessoaRepository.Read();
        return Ok(pessoas);
    }

    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Pessoa>> PessoaReadId(Guid id)
    {
        IEnumerable<Pessoa> pessoas = _pessoaRepository.Read(id);
        return Ok(pessoas);
    }

    [HttpPost]
    public ActionResult PessoaCreate(Pessoa pessoaModel)
    {
        _pessoaRepository.Create(pessoaModel);
        return Created();
    }


    [HttpPut("{id}")]
    public ActionResult PessoaUpdate(Pessoa pessoaModel, Guid id) 
    {
        _pessoaRepository.Update(pessoaModel, id);
        return Ok();
    }


    [HttpDelete("{id}")]
    public ActionResult<Pessoa> PessoaDelete(Guid id)
    {
        _pessoaRepository.Delete(id);
        return Ok();
    }
}