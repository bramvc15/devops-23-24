using BlazorApp.Models;
using Microsoft.AspNetCore.Mvc;
using Shared;
using BlazorApp.Services.Core;

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
    public Task<IEnumerable<AppointmentDTO>> GetContent()
    {
        return _service.GetContent();
    }

    [HttpGet]
    [Route("{id}")]
    public Task<AppointmentDTO> GetAppointmentById(int id)
    {
        return _service.GetAppointmentById(id);
    }

    [HttpGet]
    [Route("byDoctorId/{doctorId}")]
    public Task<IEnumerable<AppointmentDTO>> GetAppointmentsByDoctorId(int doctorId)
    {
        return _service.GetAppointmentsByDoctorId(doctorId);
    }

    [HttpGet]
    [Route("byPatientId/{patientId}")]
    public Task<IEnumerable<AppointmentDTO>> GetAppointmentsByPatientId(int patientId)
    {
        return _service.GetAppointmentsByPatientId(patientId);
    }

    [HttpPost]
    public void CreateAppointment([FromBody] AppointmentDTO appointment)
    {
        _ = _service.CreateAppointment(appointment);
    }

    [HttpPut]
    [Route("{id}")]
    public void UpdateAppointmentById(int id, [FromBody] AppointmentDTO appointment)
    {
        _service.UpdateAppointmentById(id, appointment);
    }

    [HttpDelete]
    [Route("{id}")]
    public void DeleteAppointmentById(int id)
    {
        _service.DeleteAppointmentById(id);
    }
}