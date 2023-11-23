using BlazorApp.Services;
using BlazorApp.Models;
using BlazorApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using BlazorApp.Pages;

namespace BlazorApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TimeSlotController : ControllerBase
{
    TimeSlotService _service;

    public TimeSlotController(TimeSlotService service)
    {
        _service = service;
    }

    [HttpGet]
    public Task<IEnumerable<TimeSlot>> GetTimeSlots()
    {
        return _service.GetTimeSlots();
    }

    [HttpGet("{id}")]
    public async Task<TimeSlot> GetTimeSlotById(int Id)
    {
        return await _service.GetTimeSlotById(Id);
    }

    [HttpPost]
    [Route("postTimeSlot")]
    public void AddTimeSlot(int DoctorId, [FromBody] TimeSlot timeSlot)
    {
        _service.AddTimeSlot(timeSlot);
    }

    [HttpPut("{Id:int}")]
    public void UpdateTimeSlot(int id, [FromBody] TimeSlot timeSlot)
    {
        _service.UpdateTimeSlot(id, timeSlot);
    }

    [HttpDelete]
    [Route("removeTimeSlot/{Id}")]
    public void DeleteTimeSlot(int Id)
    {
        _service.DeleteTimeSlot(Id);
    }
}