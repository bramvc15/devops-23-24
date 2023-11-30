using Microsoft.AspNetCore.Mvc;
using BlazorApp.Services.Core;
using Shared;

namespace BlazorApp.Controllers.core;

[ApiController]
[Route("api/[controller]")]
public class AppointmentController : ControllerBase
{
    private readonly AppointmentService _service;

    public AppointmentController(AppointmentService service)
    {
        _service = service;
    }

    [HttpGet]
    public Task<IEnumerable<AppointmentDTO>> GetAppointments([FromBody] PatientDTO pat)
    {
        return _service.GetAppointments(pat);
    }

    [HttpPost]
    public Task<AppointmentDTO> CreateAppointment(int slotId, int patientId, string note, string reason)
    {
        return _service.CreateAppointment(slotId, patientId, note, reason);
    }

    [HttpPut]
    public Task<AppointmentDTO> UpdateAppointment([FromBody] AppointmentDTO appointment) 
    { 
        return _service.UpdateAppointment(appointment);
    }

    [HttpDelete]
    public Task DeleteAppointment([FromBody] AppointmentDTO appointment) 
    { 
        return _service.DeleteAppointment(appointment);
    }
}