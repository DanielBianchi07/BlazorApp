using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CursoController : ControllerBase
{
    private readonly ICursoSqlRepository _cursoRepository;

    public CursoController(ICursoSqlRepository cursoRepository)
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
        return Created();
    }


    [HttpPut("{id}")]
    public ActionResult CursoUpdate(Curso cursoModel, Guid id) 
    {
        _cursoRepository.Update(cursoModel, id);
        return Ok();
    }


    [HttpDelete("{id}")]
    public ActionResult<Curso> CursoDelete(Guid id)
    {
        _cursoRepository.Delete(id);
        return Ok();
    }
}