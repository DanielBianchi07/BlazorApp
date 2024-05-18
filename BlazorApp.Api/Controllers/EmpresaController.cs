using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmpresaController : ControllerBase
{
    private readonly IEmpresaSqlRepository _empresaRepository;

    public EmpresaController(IEmpresaSqlRepository empresaRepository)
    {
        _empresaRepository = empresaRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<Empresa>> EmpresaRead()
    {
        IEnumerable<Empresa> empresas = _empresaRepository.Read();
        return Ok(empresas);
    }

    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Empresa>> EmpresaReadId(Guid id)
    {
        IEnumerable<Empresa> empresas = _empresaRepository.Read(id);
        return Ok(empresas);
    }

    [HttpPost]
    public ActionResult EmpresaCreate(Empresa empresaModel)
    {
        _empresaRepository.Create(empresaModel);
        return Ok(EmpresaModel);
    }


    [HttpPut("{id}")]
    public ActionResult EmpresaUpdate(Empresa empresaModel, Guid id) 
    {
        _empresaRepository.Update(empresaModel, id);
        return Ok();
    }


    [HttpDelete("{id}")]
    public ActionResult<Empresa> EmpresaDelete(Guid id)
    {
        _empresaRepository.Delete(id);
        return Ok();
    }
}