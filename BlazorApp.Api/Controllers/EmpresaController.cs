using BlazorApp.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmpresaController : ControllerBase
{
    private readonly IEmpresaRepository _empresaRepository;

    public EmpresaController(IEmpresaRepository empresaRepository)
    {
        _empresaRepository = empresaRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<Empresa>> Read()
    {
        IEnumerable<Empresa> empresas = _empresaRepository.Read();
        return Ok(empresas);
    }

    [HttpPost]
    public ActionResult Create(Empresa empresaModel)
    {
        _empresaRepository.Create(empresaModel);
        return Created();
    }


    [HttpPut("{id}")]
    public ActionResult Update(Empresa empresaModel, Guid id) 
    {
        _empresaRepository.Update(empresaModel, id);
        return Ok();
    }


    [HttpDelete("{id}")]
    public ActionResult<Empresa> Delete(Guid id)
    {
        _empresaRepository.Delete(id);
        return Ok();
    }
}