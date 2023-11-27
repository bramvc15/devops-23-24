using BlazorApp.Services;
using BlazorApp.Models;
using Microsoft.AspNetCore.Mvc;
using BlazorApp.Pages;

namespace BlazorApp.Controllers.core;

[ApiController]
[Route("api/[controller]")]
public class PatientController : ControllerBase
{
    PatientService _service;

    public PatientController(PatientService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("getPatients")]
    public async Task<IEnumerable<Patient>> GetContent()
    {
        return await _service.GetContent();
    }

    [HttpPost]
    [Route("updatePatient")]
    public void UpdateContent(int Id, string Name, string Email, string PhoneNumber)
    {
        _service.UpdatePatient(Id, Name, Email, PhoneNumber);
    }
}