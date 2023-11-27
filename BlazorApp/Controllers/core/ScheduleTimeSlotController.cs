using BlazorApp.Services;
using BlazorApp.Models;
using Microsoft.AspNetCore.Mvc;
using BlazorApp.Pages;

namespace BlazorApp.Controllers.core;

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
    [Route("getScheduleTimeSlotById/{id}")]
    public Task<ScheduleTimeSlot> GetScheduleTimeSlotById(int Id)
    {
        return _service.GetScheduleTimeSlotById(Id);
    }

    [HttpGet]
    [Route("getScheduleTimeSlotsByDoctorId/{DoctorId}")]
    public Task<List<ScheduleTimeSlot>> GetScheduleTimeSlotsByDoctorId(int DoctorId)
    {
        return _service.GetScheduleTimeSlotsByDoctorId(DoctorId);
    }

    [HttpPost]
    [Route("addScheduleTimeSlot")]
    public void AddScheduleTimeSlot(int DoctorId, AppointmentType AppointmentType, string DayOfWeek, DateTime DateTime, int Duration)
    {
        _service.AddScheduleTimeSlot(DoctorId, AppointmentType, DayOfWeek, DateTime, Duration);
    }

    [HttpPut]
    [Route("updateScheduleTimeSlot")]
    public void UpdateScheduleTimeSlot(int Id, int DoctorId, AppointmentType AppointmentType, string DayOfWeek, DateTime DateTime, int Duration)
    {
        _service.UpdateScheduleTimeSlot(Id, DoctorId, AppointmentType, DayOfWeek, DateTime, Duration);
    }

    [HttpDelete]
    [Route("deleteScheduleTimeSlot")]
    public void DeleteScheduleTimeSlot(int Id)
    {
        _service.DeleteScheduleTimeSlot(Id);
    }
}