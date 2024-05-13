using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioSqlRepository _usuarioRepository;

    public UsuarioController(IUsuarioSqlRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<Usuario>> UsuarioRead()
    {
        IEnumerable<Usuario> usuarios = _usuarioRepository.Read();
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Usuario>> UsuarioReadId(Guid id)
    {
        IEnumerable<Usuario> usuarios = _usuarioRepository.Read(id);
        return Ok(usuarios);
    }

    [HttpPost]
    public ActionResult UsuarioCreate(Usuario usuarioModel)
    {
        _usuarioRepository.Create(usuarioModel);
        return Created();
    }


    [HttpPut("{id}")]
    public ActionResult UsuarioUpdate(Usuario usuarioModel, Guid id) 
    {
        _usuarioRepository.Update(usuarioModel, id);
        return Ok();
    }


    [HttpDelete("{id}")]
    public ActionResult<Usuario> UsuarioDelete(Guid id)
    {
        _usuarioRepository.Delete(id);
        return Ok();
    }
}