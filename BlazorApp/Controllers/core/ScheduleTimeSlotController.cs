using Microsoft.AspNetCore.Mvc;
using Shared;
using Services.Core;

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
    public Task<IEnumerable<ScheduleTimeSlotDTO>> GetScheduleTimeSlots([FromBody] DoctorDTO doc)
    {
        return _service.GetScheduleTimeSlots(doc);
    }

    [HttpPost]
    public Task<ScheduleTimeSlotDTO> CreateScheduleTimeSlot([FromBody] ScheduleTimeSlotDTO dto, int docId) 
    { 
        return _service.CreateScheduleTimeSlot(dto, docId);
    }

    [HttpPut]
    public Task<ScheduleTimeSlotDTO> UpdateScheduleTimeSlot([FromBody] ScheduleTimeSlotDTO dto, int docId)
    {
        return _service.UpdateScheduleTimeSlot(dto, docId);
    }

    [HttpDelete]
    public Task DeleteScheduleTimeSlot([FromBody] ScheduleTimeSlotDTO dto, int docId)
    {
        return _service.DeleteScheduleTimeSlot(dto, docId);
    }
}