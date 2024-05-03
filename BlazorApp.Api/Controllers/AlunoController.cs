using Microsoft.AspNetCore.Mvc;
using BlazorSystem.Api.Models;

namespace BlazorSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlunoController : ControllerBase
{
    private readonly IAlunoRepository _alunoRepository;

    public AlunoController(IAlunoRepository alunoRepository)
    {
        _alunoRepository = alunoRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<Aluno>> AlunoRead()
    {
        IEnumerable<Aluno> alunos = _alunoRepository.Read();
        return Ok(alunos);
    }

    [HttpPost]
    public ActionResult AlunoCreate(Aluno alunoModel)
    {
        _alunoRepository.Create(alunoModel);
        return RedirectToAction("Read");
    }


    [HttpPut("{id}")]
    public ActionResult AlunoUpdate(Aluno alunoModel, Guid id) 
    {
        _alunoRepository.Update(alunoModel, id);
        return RedirectToAction("Read");
    }


    [HttpDelete("{id}")]
    public ActionResult<Aluno> AlunoDelete(Guid id)
    {
        _alunoRepository.Delete(id);
        return RedirectToAction("Read");
    }
}