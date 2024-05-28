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
    public ActionResult<Usuario> UsuarioReadId(Guid id)
    {
        Usuario usuario = _usuarioRepository.Read(id);
        return Ok(usuario);
    }
    
    [HttpGet("{nome}/{senha}")]
    public ActionResult<Usuario> UsuarioReadNomeSenha(string nome, string senha)
    {
        Usuario usuario = _usuarioRepository.ReadNomeSenha(nome, senha);
        return Ok(usuario);
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