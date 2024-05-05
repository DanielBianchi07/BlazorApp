using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;

namespace BlazorApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CursoQuestaoController : ControllerBase
{
    private readonly ICursoQuestaoRepository _cursoQuestaoRepository;

    public CursoQuestaoController(ICursoQuestaoRepository cursoQuestaoRepository)
    {
        _cursoQuestaoRepository = cursoQuestaoRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<CursoQuestao>> CursoQuestaoRead()
    {
        IEnumerable<CursoQuestao> cursoQuestoes = _cursoQuestaoRepository.Read();
        return Ok(cursoQuestoes);
    }

    [HttpPost]
    public ActionResult CursoQuestaoCreate(CursoQuestao cursoQuestaoModel)
    {
        _cursoQuestaoRepository.Create(cursoQuestaoModel);
        return Created();
    }


    [HttpPut("{id}")]
    public ActionResult CursoQuestaoUpdate(CursoQuestao cursoQuestaoModel, Guid id) 
    {
        _cursoQuestaoRepository.Update(cursoQuestaoModel, id);
        return Ok();
    }


    [HttpDelete("{id}")]
    public ActionResult<CursoQuestao> CursoQuestaoDelete(Guid id)
    {
        _cursoQuestaoRepository.Delete(id);
        return Ok();
    }
}