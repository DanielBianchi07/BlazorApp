using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;

namespace BlazorApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ListaPresencaController : ControllerBase
{
    private readonly IListaPresencaRepository _listaPresencaRepository;

    public ListaPresencaController(IListaPresencaRepository listaPresencaRepository)
    {
        _listaPresencaRepository = listaPresencaRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<ListaPresenca>> ListaPresencaRead()
    {
        IEnumerable<ListaPresenca> listaPresencas = _listaPresencaRepository.Read();
        return Ok(listaPresencas);
    }

    [HttpPost]
    public ActionResult ListaPresencaCreate(ListaPresenca listaPresencaModel)
    {
        _listaPresencaRepository.Create(listaPresencaModel);
        return Created();
    }


    [HttpPut("{id}")]
    public ActionResult ListaPresencaUpdate(ListaPresenca listaPresencaModel, Guid id) 
    {
        _listaPresencaRepository.Update(listaPresencaModel, id);
        return Ok();
    }


    [HttpDelete("{id}")]
    public ActionResult<ListaPresenca> ListaPresencaDelete(Guid id)
    {
        _listaPresencaRepository.Delete(id);
        return Ok();
    }
}