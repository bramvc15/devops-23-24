using BlazorApp.Models;
using Microsoft.AspNetCore.Mvc;
using BlazorApp.Pages;
using Shared;
using BlazorApp.Services.Core;

namespace BlazorApp.Controllers.core;

[ApiController]
[Route("api/[controller]")]
public class PatientController : ControllerBase
{
    private readonly PatientService _service;

    public PatientController(PatientService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<PatientDTO>> GetContent()
    {
        return await _service.GetContent();
    }

    [HttpPost]
    public void UpdateContent(PatientDTO request)
    {
        _service.UpdatePatient(request);
    }
}