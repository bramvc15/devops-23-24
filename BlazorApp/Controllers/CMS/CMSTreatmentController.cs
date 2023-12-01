using BlazorApp.Models;
using Microsoft.AspNetCore.Mvc;
using BlazorApp.Pages;
using Shared;
using Services.CMS;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace BlazorApp.Controllers.CMS;

[ApiController]
[Route("api/[controller]")]
public class CMSTreatmentController : ControllerBase
{
    private readonly CMSTreatmentService _service;

    public CMSTreatmentController(CMSTreatmentService service)
    {
        _service = service;
    }

    [HttpGet]
    public Task<IEnumerable<CMSTreatment>> GetTreatments()
    {
        return _service.GetTreatments();
    }

    [HttpPost]
    public Task<CMSTreatment> CreateTreatment([FromBody] CMSTreatment request)
    {
        return _service.CreateTreatment(request);
    }

    [HttpPut]
    public Task<CMSTreatment> UpdateTreatment([FromBody] CMSTreatment request)
    {
        return _service.UpdateTreatment(request);
    }

    [HttpDelete]
    public Task DeleteTreatment([FromBody] CMSTreatment request)
    {
        return _service.DeleteTreatment(request);
    }
}
