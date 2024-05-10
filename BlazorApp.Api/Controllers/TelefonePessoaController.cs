using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TelefonePessoaController : ControllerBase
{
    private readonly ITelefonePessoaSqlRepository _telefonePessoaRepository;

    public TelefonePessoaController(ITelefonePessoaSqlRepository telefonePessoaRepository)
    {
        _telefonePessoaRepository = telefonePessoaRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<TelefonePessoa>> TelefonePessoaRead()
    {
        IEnumerable<TelefonePessoa> telefonePessoas = _telefonePessoaRepository.Read();
        return Ok(telefonePessoas);
    }

    [HttpGet("{id}")]
    public ActionResult<IEnumerable<TelefonePessoa>> TelefonePessoaReadId()
    {
        IEnumerable<TelefonePessoa> telefonePessoas = _telefonePessoaRepository.Read();
        return Ok(telefonePessoas);
    }

    [HttpPost]
    public ActionResult TelefonePessoaCreate(TelefonePessoa telefonePessoaModel, Guid idPessoa)
    {
        _telefonePessoaRepository.Create(telefonePessoaModel, idPessoa);
        return Created();
    }


    [HttpPut("{id}")]
    public ActionResult TelefonePessoaUpdate(TelefonePessoa telefonePessoaModel, Guid idPessoa, Guid idTelefone) 
    {
        _telefonePessoaRepository.Update(telefonePessoaModel, idPessoa, idTelefone);
        return Ok();
    }


    [HttpDelete("{id}")]
    public ActionResult<TelefonePessoa> TelefonePessoaDelete(Guid idPessoa, Guid idTelefone)
    {
        _telefonePessoaRepository.Delete(idPessoa, idTelefone);
        return Ok();
    }
}