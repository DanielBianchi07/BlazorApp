using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProvaController : ControllerBase
{
    private readonly IProvaSqlRepository _provaRepository;

    public ProvaController(IProvaSqlRepository provaRepository)
    {
        _provaRepository = provaRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<Prova>> ProvaRead()
    {
        IEnumerable<Prova> provas = _provaRepository.Read();
        return Ok(provas);
    }

    [HttpGet("{idProva}/{idPessoa}")]
    public ActionResult<IEnumerable<Prova>> ProvaReadId(Guid idProva, Guid idPessoa)
    {
        IEnumerable<Prova> provas = _provaRepository.Read(idProva, idPessoa);
        return Ok(provas);
    }

    [HttpPost]
    public ActionResult ProvaCreate(Prova provaModel)
    {
        _provaRepository.Create(provaModel);
        return Created();
    }


    [HttpPut("{idProva}/{idPessoa}")]
    public ActionResult ProvaUpdate(Prova provaModel, Guid idProva, Guid idPessoa) 
    {
        _provaRepository.Update(provaModel, idProva, idPessoa);
        return Ok();
    }


    [HttpDelete("{idProva}/{idPessoa}")]
    public ActionResult<Prova> ProvaDelete(Guid idProva, Guid idPessoa)
    {
        _provaRepository.Delete(idProva, idPessoa);
        return Ok();
    }
}