using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlunoController : ControllerBase
{
    private readonly IAlunoSqlRepository _alunoRepository;

    public AlunoController(IAlunoSqlRepository alunoRepository)
    {
        _alunoRepository = alunoRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<Aluno>> AlunoRead()
    {
        IEnumerable<Aluno> alunos = _alunoRepository.Read();
        return Ok(alunos);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Aluno>> AlunoReadId(Guid id)
    {
        IEnumerable<Aluno> alunos = _alunoRepository.Read(id);
        return Ok(alunos);
    }

    [HttpPost]
    public ActionResult AlunoCreate(Aluno alunoModel)
    {
        _alunoRepository.Create(alunoModel);
        return Created();
    }


    [HttpPut("{id}")]
    public ActionResult AlunoUpdate(Aluno alunoModel, Guid id) 
    {
        _alunoRepository.Update(alunoModel, id);
        return Ok();
    }


    [HttpDelete("{id}")]
    public ActionResult<Aluno> AlunoDelete(Guid id)
    {
        _alunoRepository.Delete(id);
        return Ok();
    }
}