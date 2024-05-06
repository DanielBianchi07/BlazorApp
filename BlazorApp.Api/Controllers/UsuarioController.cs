using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;

namespace BlazorApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<Usuario>> UsuarioRead()
    {
        IEnumerable<Usuario> usuarios = _usuarioRepository.Read();
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