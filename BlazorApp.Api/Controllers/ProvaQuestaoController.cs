using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProvaQuestaoController : ControllerBase
{
    private readonly IProvaQuestaoSqlRepository _provaQuestaoRepository;

    public ProvaQuestaoController(IProvaQuestaoSqlRepository provaQuestaoRepository)
    {
        _provaQuestaoRepository = provaQuestaoRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<ProvaQuestao>> ProvaQuestaoRead()
    {
        IEnumerable<ProvaQuestao> provaQuestoes = _provaQuestaoRepository.Read();
        return Ok(provaQuestoes);
    }

    [HttpGet("{idQuestao}/{idProva}")]
    public ActionResult<ProvaQuestao> ProvaQuestaoReadId(Guid idQuestao, Guid idProva)
    {
        ProvaQuestao provaQuestoe = _provaQuestaoRepository.Read(idQuestao, idProva);
        return Ok(provaQuestoe);
    }

    [HttpPost]
    public ActionResult ProvaQuestaoCreate(ProvaQuestao provaQuestaoModel)
    {
        _provaQuestaoRepository.Create(provaQuestaoModel);
        return Created();
    }


    [HttpPut("{id}")]
    public ActionResult ProvaQuestaoUpdate(ProvaQuestao provaQuestaoModel, Guid id) 
    {
        _provaQuestaoRepository.Update(provaQuestaoModel, id);
        return Ok();
    }


    [HttpDelete("{idQuestao}/{idProva}")]
    public ActionResult<ProvaQuestao> ProvaQuestaoDelete(Guid idQuestao, Guid idProva)
    {
        _provaQuestaoRepository.Delete(idQuestao, idProva);
        return Ok();
    }
}