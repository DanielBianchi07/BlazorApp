using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EnderecoEmpresaController : ControllerBase
{
    private readonly IEnderecoEmpresaSqlRepository _enderecoEmpresaRepository;

    public EnderecoEmpresaController(IEnderecoEmpresaSqlRepository enderecoEmpresaRepository)
    {
        _enderecoEmpresaRepository = enderecoEmpresaRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<EnderecoEmpresa>> EnderecoEmpresaRead()
    {
        IEnumerable<EnderecoEmpresa> enderecoEmpresas = _enderecoEmpresaRepository.Read();
        return Ok(enderecoEmpresas);
    }

    [HttpGet]
    public ActionResult<IEnumerable<EnderecoEmpresa>> EnderecoEmpresaReadId(Guid id)
    {
        IEnumerable<EnderecoEmpresa> enderecoEmpresas = _enderecoEmpresaRepository.Read(id);
        return Ok(enderecoEmpresas);
    }

    [HttpPost]
    public ActionResult EnderecoEmpresaCreate(EnderecoEmpresa enderecoEmpresaModel)
    {
        _enderecoEmpresaRepository.Create(enderecoEmpresaModel);
        return Created();
    }


    [HttpPut("{id}")]
    public ActionResult EnderecoEmpresaUpdate(EnderecoEmpresa enderecoEmpresaModel, Guid id) 
    {
        _enderecoEmpresaRepository.Update(enderecoEmpresaModel, id);
        return Ok();
    }


    [HttpDelete("{id}")]
    public ActionResult<EnderecoEmpresa> EnderecoEmpresaDelete(Guid id)
    {
        _enderecoEmpresaRepository.Delete(id);
        return Ok();
    }
}