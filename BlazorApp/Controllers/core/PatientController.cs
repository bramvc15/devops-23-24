using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Core;
using Shared.DTO.Core;

namespace BlazorApp.Controllers.core;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PatientController : ControllerBase
{
    private readonly PatientService _service;

    public PatientController(PatientService service)
    {
        _service = service;
    }

    [HttpGet]
    public Task<IEnumerable<PatientDTO>> GetPatients()
    {
        return _service.GetPatients();
    }

    [HttpPost]
    public Task<PatientDTO> CreatePatient([FromBody] PatientDTO patient) 
    { 
        return _service.CreatePatient(patient);
    }

    [HttpPut]
    public Task<PatientDTO> UpdatePatient([FromBody] PatientDTO request)
    {
        return _service.UpdatePatient(request);
    }
}