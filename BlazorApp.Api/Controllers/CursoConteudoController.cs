using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CursoConteudoController : ControllerBase
{
    private readonly ICursoConteudoSqlRepository _cursoConteudoRepository;

    public CursoConteudoController(ICursoConteudoSqlRepository cursoConteudoRepository)
    {
        _cursoConteudoRepository = cursoConteudoRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<CursoConteudo>> CursoConteudoRead()
    {
        IEnumerable<CursoConteudo> cursoConteudos = _cursoConteudoRepository.Read();
        return Ok(cursoConteudos);
    }

    [HttpGet("{idCurso}/{idConteudo}")]
    public ActionResult<CursoConteudo> CursoConteudoReadId(Guid idCurso, Guid idConteudo)
    {
        CursoConteudo cursoConteudo = _cursoConteudoRepository.Read(idCurso, idConteudo);
        return Ok(cursoConteudo);
    }

    [HttpPost]
    public ActionResult CursoConteudoCreate(CursoConteudo cursoConteudoModel)
    {
        _cursoConteudoRepository.Create(cursoConteudoModel);
        return Created();
    }


    [HttpPut("{idCurso}/{idConteudo}")]
    public ActionResult CursoConteudoUpdate(CursoConteudo cursoConteudoModel, Guid idCurso, Guid idConteudo) 
    {
        _cursoConteudoRepository.Update(cursoConteudoModel, idCurso, idConteudo);
        return Ok();
    }


    [HttpDelete("{idCurso}/{idConteudo}")]
    public ActionResult<CursoConteudo> CursoConteudoDelete(Guid idCurso, Guid idConteudo)
    {
        _cursoConteudoRepository.Delete(idCurso, idConteudo);
        return Ok();
    }
}