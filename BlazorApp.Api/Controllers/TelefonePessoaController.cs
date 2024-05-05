using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;

namespace BlazorApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TelefonePessoaController : ControllerBase
{
    private readonly ITelefonePessoaRepository _telefonePessoaRepository;

    public TelefonePessoaController(ITelefonePessoaRepository telefonePessoaRepository)
    {
        _telefonePessoaRepository = telefonePessoaRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<TelefonePessoa>> TelefonePessoaRead()
    {
        IEnumerable<TelefonePessoa> telefonePessoas = _telefonePessoaRepository.Read();
        return Ok(telefonePessoas);
    }

    [HttpPost]
    public ActionResult TelefonePessoaCreate(TelefonePessoa telefonePessoaModel)
    {
        _telefonePessoaRepository.Create(telefonePessoaModel);
        return Created();
    }


    [HttpPut("{id}")]
    public ActionResult TelefonePessoaUpdate(TelefonePessoa telefonePessoaModel, Guid id) 
    {
        _telefonePessoaRepository.Update(telefonePessoaModel, id);
        return Ok();
    }


    [HttpDelete("{id}")]
    public ActionResult<TelefonePessoa> TelefonePessoaDelete(Guid id)
    {
        _telefonePessoaRepository.Delete(id);
        return Ok();
    }
}