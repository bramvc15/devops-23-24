using BlazorApp.Models;
using Microsoft.AspNetCore.Mvc;
using BlazorApp.Pages;
using Shared;
using Domain;
using BlazorApp.Services.Core;

namespace BlazorApp.Controllers.core;

[ApiController]
[Route("api/[controller]")]
public class ScheduleTimeSlotController : ControllerBase
{
    private readonly ScheduleTimeSlotService _service;

    public ScheduleTimeSlotController(ScheduleTimeSlotService service)
    {
        _service = service;
    }

    [HttpGet]
    public Task<List<ScheduleTimeSlotDTO>> GetScheduleTimeSlots()
    {
        return _service.GetScheduleTimeSlots();
    }

    [HttpGet]
    [Route("{id}")]
    public Task<ScheduleTimeSlotDTO> GetScheduleTimeSlotById(int Id)
    {
        return _service.GetScheduleTimeSlotById(Id);
    }

    [HttpGet]
    [Route("byDoctorId/{DoctorId}")]
    public Task<List<ScheduleTimeSlotDTO>> GetScheduleTimeSlotsByDoctorId(int DoctorId)
    {
        return _service.GetScheduleTimeSlotsByDoctorId(DoctorId);
    }

    [HttpPost]
    public void AddScheduleTimeSlot(int DoctorId, AppointmentType AppointmentType, string DayOfWeek, DateTime DateTime, int Duration)
    {
        _service.AddScheduleTimeSlot(DoctorId, AppointmentType, DayOfWeek, DateTime, Duration);
    }

    [HttpPut]
    public void UpdateScheduleTimeSlot(int Id, int DoctorId, AppointmentType AppointmentType, string DayOfWeek, DateTime DateTime, int Duration)
    {
        _service.UpdateScheduleTimeSlot(Id, DoctorId, AppointmentType, DayOfWeek, DateTime, Duration);
    }

    [HttpDelete]
    public async Task DeleteScheduleTimeSlot(int Id)
    {
        await _service.DeleteScheduleTimeSlot(Id);
    }
}