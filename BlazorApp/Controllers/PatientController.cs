using BlazorApp.Services;
using BlazorApp.Models;
using BlazorApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using BlazorApp.Pages;

namespace BlazorApp.Controllers;

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
    public IEnumerable<Patient> GetContent()
    {

        return _service.GetContent();

    }

    [HttpPost]
    [Route("updatePatient")]
    public void UpdateContent(int Id, string Name, string Email, string PhoneNumber)
    {
        _service.UpdatePatient(Id, Name, Email, PhoneNumber);
    }
}