using Microsoft.AspNetCore.Mvc;
using Services.Core;
using Shared.DTO.Core;

namespace BlazorApp.Controllers;

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
    public async Task<ActionResult<IEnumerable<AppointmentDTO>>> GetAppointments()
    {
        try
        {
            var appointments = await _service.GetAppointments();

            if (appointments == null)
            {
                return NotFound();
            }

            return Ok(appointments);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost]
    public async Task<ActionResult<AppointmentDTO>> CreateAppointment(int slotId, int patientId, string note, string reason)
    {
        try
        {
            var appointment = _service.CreateAppointment(slotId, patientId, note, reason);

            if (appointment == null)
            {
                return BadRequest();
            }

            return Ok(appointment);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPut]
    public async Task<ActionResult<AppointmentDTO>> UpdateAppointment([FromBody] AppointmentDTO appointment)
    {
        try
        {
            var updatedAppointment = _service.UpdateAppointment(appointment);

            if (updatedAppointment == null)
            {
                return BadRequest();
            }

            return Ok(updatedAppointment);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteAppointment([FromBody] AppointmentDTO appointment)
    {
        try
        {
            await _service.DeleteAppointment(appointment);
            return Ok();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "Internal server error");
        }
    }
}