using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ListaPresencaController : ControllerBase
{
    private readonly IListaPresencaSqlRepository _listaPresencaRepository;

    public ListaPresencaController(IListaPresencaSqlRepository listaPresencaRepository)
    {
        _listaPresencaRepository = listaPresencaRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<ListaPresenca>> ListaPresencaRead()
    {
        IEnumerable<ListaPresenca> listaPresencas = _listaPresencaRepository.Read();
        return Ok(listaPresencas);
    }

    [HttpGet("{id}")]
    public ActionResult<IEnumerable<ListaPresenca>> ListaPresencaReadId(Guid id)
    {
        IEnumerable<ListaPresenca> listaPresencas = _listaPresencaRepository.Read(id);
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