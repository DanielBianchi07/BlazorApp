using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;

namespace BlazorSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EnderecoEmpresaController : ControllerBase
{
    private readonly IEnderecoEmpresaRepository _enderecoEmpresaRepository;

    public EnderecoEmpresaController(IEnderecoEmpresaRepository enderecoEmpresaRepository)
    {
        _enderecoEmpresaRepository = enderecoEmpresaRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<EnderecoEmpresa>> EnderecoEmpresaRead()
    {
        IEnumerable<EnderecoEmpresa> enderecoEmpresas = _enderecoEmpresaRepository.Read();
        return Ok(enderecoEmpresas);
    }

    [HttpPost]
    public ActionResult EnderecoEmpresaCreate(EnderecoEmpresa enderecoEmpresaModel)
    {
        _enderecoEmpresaRepository.Create(enderecoEmpresaModel);
        return RedirectToAction("Read");
    }


    [HttpPut("{id}")]
    public ActionResult EnderecoEmpresaUpdate(EnderecoEmpresa enderecoEmpresaModel, Guid id) 
    {
        _enderecoEmpresaRepository.Update(enderecoEmpresaModel, id);
        return RedirectToAction("Read");
    }


    [HttpDelete("{id}")]
    public ActionResult<EnderecoEmpresa> EnderecoEmpresaDelete(Guid id)
    {
        _enderecoEmpresaRepository.Delete(id);
        return RedirectToAction("Read");
    }
}