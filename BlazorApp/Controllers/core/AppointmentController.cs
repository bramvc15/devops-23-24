using Microsoft.AspNetCore.Mvc;
using Services.Core;
using Shared.DTO.Core;
using Microsoft.AspNetCore.Authorization;

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
    [Authorize]
    public Task<IEnumerable<AppointmentDTO>> GetAppointments()
    {
        return _service.GetAppointments();
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