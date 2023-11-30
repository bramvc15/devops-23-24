using Microsoft.AspNetCore.Mvc;
using BlazorApp.Services.Core;
using Shared;

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
    public Task<IEnumerable<TimeSlotDTO>> GetTimeSlots([FromBody] DoctorDTO doc)
    {
        return _service.GetTimeSlots(doc);
    }

    [HttpPost]
    public Task<TimeSlotDTO> CreateTimeSlot([FromBody] TimeSlotDTO dto, int docId)
    {
        return _service.CreateTimeSlot(dto, docId);
    }
    
    [HttpPut]
    public Task<TimeSlotDTO> UpdateTimeSlot([FromBody] TimeSlotDTO dto, int docId)
    {
        return _service.UpdateTimeSlot(dto, docId);
    }

    [HttpDelete]
    public Task DeleteTimeSlot([FromBody] TimeSlotDTO dto, int docId)
    {
        return _service.DeleteTimeSlot(dto, docId);
    }
}