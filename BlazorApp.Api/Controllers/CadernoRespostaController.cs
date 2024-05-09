using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CadernoRespostaController : ControllerBase
{
    private readonly ICadernoRespostaSqlRepository _cadernoRespostaRepository;

    public CadernoRespostaController(ICadernoRespostaSqlRepository cadernoRespostaRepository)
    {
        _cadernoRespostaRepository = cadernoRespostaRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<CadernoResposta>> CadernoRespostaRead()
    {
        IEnumerable<CadernoResposta> cadernoRespostas = _cadernoRespostaRepository.Read();
        return Ok(cadernoRespostas);
    }

    [HttpPost]
    public ActionResult CadernoRespostaCreate(CadernoResposta cadernoRespostaModel)
    {
        _cadernoRespostaRepository.Create(cadernoRespostaModel);
        return Created();
    }


    [HttpPut("{id}")]
    public ActionResult CadernoRespostaUpdate(CadernoResposta cadernoRespostaModel, Guid id) 
    {
        _cadernoRespostaRepository.Update(cadernoRespostaModel, id);
        return Ok();
    }


    [HttpDelete("{id}")]
    public ActionResult<CadernoResposta> CadernoRespostaDelete(Guid id)
    {
        _cadernoRespostaRepository.Delete(id);
        return Ok();
    }
}