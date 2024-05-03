using Microsoft.AspNetCore.Mvc;
using BlazorSystem.Api.Models;

namespace BlazorSystem.Api.Controllers;

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
        return RedirectToAction("Read");
    }


    [HttpPut("{id}")]
    public ActionResult Update(Empresa empresaModel, Guid id) 
    {
        _empresaRepository.Update(empresaModel, id);
        return RedirectToAction("Read");
    }


    [HttpDelete("{id}")]
    public ActionResult<Empresa> Delete(Guid id)
    {
        _empresaRepository.Delete(id);
        return RedirectToAction("Read");
    }
}