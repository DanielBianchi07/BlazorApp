using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;

namespace BlazorSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CursoConteudoController : ControllerBase
{
    private readonly ICursoConteudoRepository _cursoConteudoRepository;

    public CursoConteudoController(ICursoConteudoRepository cursoConteudoRepository)
    {
        _cursoConteudoRepository = cursoConteudoRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<CursoConteudo>> CursoConteudoRead()
    {
        IEnumerable<CursoConteudo> cursoConteudos = _cursoConteudoRepository.Read();
        return Ok(cursoConteudos);
    }

    [HttpGet]
    public ActionResult<IEnumerable<CursoConteudo>> CursoConteudoReadId(Guid id)
    {
        IEnumerable<CursoConteudo> cursoConteudos = _cursoConteudoRepository.Read(id);
        return Ok(cursoConteudos);
    }

    [HttpPost]
    public ActionResult CursoConteudoCreate(CursoConteudo cursoConteudoModel)
    {
        _cursoConteudoRepository.Create(cursoConteudoModel);
        return RedirectToAction("Read");
    }


    [HttpPut("{id}")]
    public ActionResult CursoConteudoUpdate(CursoConteudo cursoConteudoModel, Guid id) 
    {
        _cursoConteudoRepository.Update(cursoConteudoModel, id);
        return RedirectToAction("Read");
    }


    [HttpDelete("{id}")]
    public ActionResult<CursoConteudo> CursoConteudoDelete(Guid id)
    {
        _cursoConteudoRepository.Delete(id);
        return RedirectToAction("Read");
    }
}