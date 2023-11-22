using BlazorApp.Services;
using BlazorApp.Models;
using BlazorApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using BlazorApp.Pages;

namespace BlazorApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppointmentController : ControllerBase
{
    AppointmentService _service;

    public AppointmentController(AppointmentService service)
    {
        _service = service;
    }

    [HttpGet]
    public Task<IEnumerable<Appointment>> GetContent()
    {
        return _service.GetContent();
    }

    [HttpGet]
    [Route("getAppointmentById/{id}")]
    public Task<Appointment> GetAppointmentById(int id)
    {
        return _service.GetAppointmentById(id);
    }

    [HttpGet]
    [Route("getAppointmentsByDoctorId/{doctorId}")]
    public Task<IEnumerable<Appointment>> GetAppointmentsByDoctorId(int doctorId)
    {
        return _service.GetAppointmentsByDoctorId(doctorId);
    }

    [HttpGet]
    [Route("getAppointmentsByPatientId/{patientId}")]
    public Task<IEnumerable<Appointment>> GetAppointmentsByPatientId(int patientId)
    {
        return _service.GetAppointmentsByPatientId(patientId);
    }

    [HttpPost]
    public void CreateAppointment([FromBody] Appointment appointment)
    {
        _ = _service.CreateAppointment(appointment);
    }

    [HttpPut]
    [Route("{id}")]
    public void UpdateAppointmentById(int id, [FromBody] Appointment appointment)
    {
        _service.UpdateAppointmentById(id, appointment);
    }

    [HttpDelete]
    public void DeleteAppointmentById(int id)
    {
        _ = _service.DeleteAppointmentById(id);
    }
}