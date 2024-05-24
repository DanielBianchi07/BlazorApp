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

    [HttpGet("{idPessoa}/{idTelefone}")]
    public ActionResult<IEnumerable<TelefonePessoa>> TelefonePessoaReadId(Guid idPessoa, Guid idTelefone)
    {
        IEnumerable<TelefonePessoa> telefonePessoas = _telefonePessoaRepository.Read(idPessoa, idTelefone);
        return Ok(telefonePessoas);
    }

    [HttpPost]
    public ActionResult TelefonePessoaCreate(TelefonePessoa telefonePessoaModel)
    {
        _telefonePessoaRepository.Create(telefonePessoaModel);
        return Created();
    }


    [HttpPut("{idPessoa}/{idTelefone}")]
    public ActionResult TelefonePessoaUpdate(TelefonePessoa telefonePessoaModel, Guid idPessoa, Guid idTelefone) 
    {
        _telefonePessoaRepository.Update(telefonePessoaModel, idPessoa, idTelefone);
        return Ok();
    }


    [HttpDelete("{idPessoa}/{idTelefone}")]
    public ActionResult<TelefonePessoa> TelefonePessoaDelete(Guid idPessoa, Guid idTelefone)
    {
        _telefonePessoaRepository.Delete(idPessoa, idTelefone);
        return Ok();
    }
}