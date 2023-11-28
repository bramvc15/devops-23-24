using BlazorApp.Models;
using Microsoft.AspNetCore.Mvc;
using BlazorApp.Pages;
using Shared;
using BlazorApp.Services.CMS;

namespace BlazorApp.Controllers.CMS;

[ApiController]
[Route("[controller]")]
public class CMSTreatmentController : ControllerBase
{
    private readonly TreatmentService _service;

    public CMSTreatmentController(TreatmentService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<CMSTreatment>> GetTreatments()
    {
        return await _service.GetTreatments();
    }

    [HttpPut]
    public async Task<CMSTreatment> UpdateTreatment(CMSTreatment request)
    {
        await _service.UpdateTreatment(request);
    }
}
