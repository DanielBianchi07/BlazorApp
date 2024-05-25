using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CursoQuestaoController : ControllerBase
{
    private readonly ICursoQuestaoSqlRepository _cursoQuestaoRepository;

    public CursoQuestaoController(ICursoQuestaoSqlRepository cursoQuestaoRepository)
    {
        _cursoQuestaoRepository = cursoQuestaoRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<CursoQuestao>> CursoQuestaoRead()
    {
        IEnumerable<CursoQuestao> cursoQuestoes = _cursoQuestaoRepository.Read();
        return Ok(cursoQuestoes);
    }

    [HttpGet("{idCurso}/{idQuestao}")]
    public ActionResult<CursoQuestao> CursoQuestaoReadId(Guid idCurso, Guid idQuestao)
    {
        CursoQuestao cursoQuestoe = _cursoQuestaoRepository.Read(idCurso, idQuestao);
        return Ok(cursoQuestoe);
    }

    [HttpPost]
    public ActionResult CursoQuestaoCreate(CursoQuestao cursoQuestaoModel)
    {
        _cursoQuestaoRepository.Create(cursoQuestaoModel);
        return Created();
    }


    [HttpPut("{idCurso}/{idQuestao}")]
    public ActionResult CursoQuestaoUpdate(CursoQuestao cursoQuestaoModel, Guid idCurso, Guid idQuestao) 
    {
        _cursoQuestaoRepository.Update(cursoQuestaoModel, idCurso, idQuestao);
        return Ok();
    }


    [HttpDelete("{idCurso}/{idQuestao}")]
    public ActionResult<CursoQuestao> CursoQuestaoDelete(Guid idCurso, Guid idQuestao)
    {
        _cursoQuestaoRepository.Delete(idCurso, idQuestao);
        return Ok();
    }
}