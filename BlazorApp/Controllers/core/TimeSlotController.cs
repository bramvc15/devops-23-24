using BlazorApp.Models;
using Microsoft.AspNetCore.Mvc;
using BlazorApp.Pages;
using Shared;
using BlazorApp.Services.Core;

namespace BlazorApp.Controllers.core;

[ApiController]
[Route("api/[controller]")]
public class TimeSlotController : ControllerBase
{
    private readonly TimeSlotService _service;

    public TimeSlotController(TimeSlotService service)
    {
        _service = service;
    }

    [HttpGet]
    public Task<IEnumerable<TimeSlotDTO>> GetTimeSlots()
    {
        return _service.GetTimeSlots();
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<TimeSlotDTO> GetTimeSlotById(int Id)
    {
        return await _service.GetTimeSlotById(Id);
    }

    [HttpPost]
    public void AddTimeSlot(int DoctorId, [FromBody] TimeSlotDTO request)
    {
        _service.AddTimeSlot(request);
    }

    [HttpPut]
    [Route("{id}")]
    public void UpdateTimeSlot(int id, [FromBody] TimeSlotDTO request)
    {
        _service.UpdateTimeSlot(id, request);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task DeleteTimeSlot(int id)
    {
        await _service.DeleteTimeSlot(id);
    }
}