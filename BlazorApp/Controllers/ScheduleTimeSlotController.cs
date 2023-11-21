using BlazorApp.Services;
using BlazorApp.Models;
using BlazorApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using BlazorApp.Pages;

namespace BlazorApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ScheduleTimeSlotController : ControllerBase
{
    ScheduleTimeSlotService _service;

    public ScheduleTimeSlotController(ScheduleTimeSlotService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("getScheduleTimeSlots")]
    public Task<List<ScheduleTimeSlot>> GetScheduleTimeSlots()
    {
        return _service.GetScheduleTimeSlots();
    }

    [HttpGet]
    [Route("getScheduleTimeSlot/{id}")]
    public Task<ScheduleTimeSlot> GetScheduleTimeSlot(int Id)
    {
        return _service.GetScheduleTimeSlot(Id);
    }

    [HttpPost]
    [Route("addScheduleTimeSlot")]
    public void AddScheduleTimeSlot(int DoctorId, AppointmentType AppointmentType, DateTime DateTime, int Duration)
    {
        _service.AddScheduleTimeSlot(DoctorId, AppointmentType, DateTime, Duration);
    }

    [HttpPut]
    [Route("updateScheduleTimeSlot")]
    public void UpdateScheduleTimeSlot(int Id, int DoctorId, AppointmentType AppointmentType, DateTime DateTime, int Duration)
    {
        _service.UpdateScheduleTimeSlot(Id, DoctorId, AppointmentType, DateTime, Duration);
    }

    [HttpDelete]
    [Route("deleteScheduleTimeSlot")]
    public void DeleteScheduleTimeSlot(int Id)
    {
        _service.DeleteScheduleTimeSlot(Id);
    }
}