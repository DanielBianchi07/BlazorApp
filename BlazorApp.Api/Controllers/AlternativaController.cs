using Microsoft.AspNetCore.Mvc;
using BlazorApp.Api.Models;

namespace BlazorSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlternativaController : ControllerBase
{
    private readonly IAlternativaRepository _alternativaRepository;

    public AlternativaController(IAlternativaRepository alternativaRepository)
    {
        _alternativaRepository = alternativaRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<Alternativa>> AlternativaRead()
    {
        IEnumerable<Alternativa> alternativas = _alternativaRepository.Read();
        return Ok(alternativas);
    }

    [HttpPost]
    public ActionResult AlternativaCreate(Alternativa alternativaModel)
    {
        _alternativaRepository.Create(alternativaModel);
        return RedirectToAction("Read");
    }


    [HttpPut("{id}")]
    public ActionResult AlternativaUpdate(Alternativa alternativaModel, Guid id) 
    {
        _alternativaRepository.Update(alternativaModel, id);
        return RedirectToAction("Read");
    }


    [HttpDelete("{id}")]
    public ActionResult<Alternativa> AlternativaDelete(Guid id)
    {
        _alternativaRepository.Delete(id);
        return RedirectToAction("Read");
    }
}