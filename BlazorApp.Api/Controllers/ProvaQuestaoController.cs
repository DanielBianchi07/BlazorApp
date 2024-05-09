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


    [HttpDelete("{id}")]
    public ActionResult<ProvaQuestao> ProvaQuestaoDelete(Guid id)
    {
        _provaQuestaoRepository.Delete(id);
        return Ok();
    }
}