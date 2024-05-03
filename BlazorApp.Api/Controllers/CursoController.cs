using Microsoft.AspNetCore.Mvc;
using BlazorSystem.Api.Models;

namespace BlazorSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CursoController : ControllerBase
{
    private readonly ICursoRepository _cursoRepository;

    public CursoController(ICursoRepository cursoRepository)
    {
        _cursoRepository = cursoRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<Curso>> CursoRead()
    {
        IEnumerable<Curso> cursos = _cursoRepository.Read();
        return Ok(cursos);
    }

    [HttpPost]
    public ActionResult CursoCreate(Curso cursoModel)
    {
        _cursoRepository.Create(cursoModel);
        return RedirectToAction("Read");
    }


    [HttpPut("{id}")]
    public ActionResult CursoUpdate(Curso cursoModel, Guid id) 
    {
        _cursoRepository.Update(cursoModel, id);
        return RedirectToAction("Read");
    }


    [HttpDelete("{id}")]
    public ActionResult<Curso> CursoDelete(Guid id)
    {
        _cursoRepository.Delete(id);
        return RedirectToAction("Read");
    }
}