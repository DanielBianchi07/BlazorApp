using Microsoft.AspNetCore.Mvc;
using BlazorSystem.Api.Models;

namespace BlazorSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CadernoRespostaController : ControllerBase
{
    private readonly ICadernoRespostaRepository _cadernoRespostaRepository;

    public CadernoRespostaController(ICadernoRespostaRepository cadernoRespostaRepository)
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
        return RedirectToAction("Read");
    }


    [HttpPut("{id}")]
    public ActionResult CadernoRespostaUpdate(CadernoResposta cadernoRespostaModel, Guid id) 
    {
        _cadernoRespostaRepository.Update(cadernoRespostaModel, id);
        return RedirectToAction("Read");
    }


    [HttpDelete("{id}")]
    public ActionResult<CadernoResposta> CadernoRespostaDelete(Guid id)
    {
        _cadernoRespostaRepository.Delete(id);
        return RedirectToAction("Read");
    }
}