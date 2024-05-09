using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlunoEmpresaController : ControllerBase
{
    private readonly IAlunoEmpresaSqlRepository _alunoEmpresaRepository;

    public AlunoEmpresaController(IAlunoEmpresaSqlRepository alunoEmpresaRepository)
    {
        _alunoEmpresaRepository = alunoEmpresaRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<AlunoEmpresa>> AlunoEmpresaRead()
    {
        IEnumerable<AlunoEmpresa> alunoEmpresas = _alunoEmpresaRepository.Read();
        return Ok(alunoEmpresas);
    }

    [HttpPost]
    public ActionResult AlunoEmpresaCreate(AlunoEmpresa alunoEmpresaModel)
    {
        _alunoEmpresaRepository.Create(alunoEmpresaModel);
        return Created();
    }


    [HttpPut]
    public ActionResult AlunoEmpresaUpdate(AlunoEmpresa alunoEmpresaModel, Guid aluno_id, Guid empresa_id) 
    {
        _alunoEmpresaRepository.Update(alunoEmpresaModel, aluno_id, empresa_id);
        return Ok();
    }


    [HttpDelete]
    public ActionResult<AlunoEmpresa> AlunoEmpresaDelete(Guid aluno_id, Guid empresa_id)
    {
        _alunoEmpresaRepository.Delete(aluno_id, empresa_id);
        return Ok();
    }
}