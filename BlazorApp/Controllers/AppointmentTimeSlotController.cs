using BlazorApp.Services;
using BlazorApp.Models;
using BlazorApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using BlazorApp.Pages;

namespace BlazorApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppointmentTimeSlotController : ControllerBase
{
    AppointmentTimeSlotService _service;

    public AppointmentTimeSlotController(AppointmentTimeSlotService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("getAppointmentTimeSlots")]
    public async Task<IEnumerable<AppointmentTimeSlot>> GetContent()
    {
        return await _service.GetContent();
    }

    [HttpPost]
    [Route("updateAppointmentTimeSlot")]
    public void UpdateContent(int Id, int Doctor_Id, int Patient_Id, DateTime DateTime, int Duration)
    {
        _service.UpdateAppointmentTimeSlot(Id, Doctor_Id, Patient_Id, DateTime, Duration);
    }
}