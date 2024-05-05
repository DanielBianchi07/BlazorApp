using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;

namespace BlazorSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProvaQuestaoController : ControllerBase
{
    private readonly IProvaQuestaoRepository _provaQuestaoRepository;

    public ProvaQuestaoController(IProvaQuestaoRepository provaQuestaoRepository)
    {
        _provaQuestaoRepository = provaQuestaoRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<ProvaQuestao>> ProvaQuestaoRead()
    {
        IEnumerable<ProvaQuestao> provaQuestoes = _provaQuestaoRepository.Read();
        return Ok(provaQuestoes);
    }

    [HttpGet]
    public ActionResult<IEnumerable<ProvaQuestao>> ProvaQuestaoReadId(Guid id)
    {
        IEnumerable<ProvaQuestao> provaQuestoes = _provaQuestaoRepository.Read(id);
        return Ok(provaQuestoes);
    }

    [HttpPost]
    public ActionResult ProvaQuestaoCreate(ProvaQuestao provaQuestaoModel)
    {
        _provaQuestaoRepository.Create(provaQuestaoModel);
        return RedirectToAction("Read");
    }


    [HttpPut("{id}")]
    public ActionResult ProvaQuestaoUpdate(ProvaQuestao provaQuestaoModel, Guid id) 
    {
        _provaQuestaoRepository.Update(provaQuestaoModel, id);
        return RedirectToAction("Read");
    }


    [HttpDelete("{id}")]
    public ActionResult<ProvaQuestao> ProvaQuestaoDelete(Guid id)
    {
        _provaQuestaoRepository.Delete(id);
        return RedirectToAction("Read");
    }
}