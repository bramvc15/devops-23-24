using Microsoft.AspNetCore.Mvc;
using BlazorApp.Pages;
using Shared;
using Services.CMS;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;
using Shared.DTO.CMS;
using Microsoft.AspNetCore.Authorization;

namespace BlazorApp.Controllers.CMS;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TreatmentController : ControllerBase
{
    private readonly TreatmentService _service;

    public TreatmentController(TreatmentService service)
    {
        _service = service;
    }

    [HttpGet]
    public Task<IEnumerable<TreatmentDTO>> GetTreatments()
    {
        return _service.GetTreatments();
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public Task<TreatmentDTO> CreateTreatment([FromBody] TreatmentDTO request)
    {
        return _service.CreateTreatment(request);
    }

    [HttpPut]
    [Authorize(Roles = "Admin")]
    public Task<TreatmentDTO> UpdateTreatment([FromBody] TreatmentDTO request)
    {
        return _service.UpdateTreatment(request);
    }

    [HttpDelete]
    [Authorize(Roles = "Admin")]
    public Task DeleteTreatment([FromBody] TreatmentDTO request)
    {
        return _service.DeleteTreatment(request);
    }
}
