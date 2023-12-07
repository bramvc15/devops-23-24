using Microsoft.AspNetCore.Mvc;
using Shared.DTO.Core;
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
    [Route("{docId}")]
    public Task<IEnumerable<ScheduleTimeSlotDTO>> GetScheduleTimeSlots(int docId)
    {
        return _service.GetScheduleTimeSlots(docId);
    }

    [HttpPost]
    [Route("{docId}")]
    public Task<ScheduleTimeSlotDTO> CreateScheduleTimeSlot([FromBody] ScheduleTimeSlotDTO dto, int docId) 
    { 
        return _service.CreateScheduleTimeSlot(dto, docId);
    }

    [HttpPut]
    [Route("{docId}")]
    public Task<ScheduleTimeSlotDTO> UpdateScheduleTimeSlot([FromBody] ScheduleTimeSlotDTO dto, int docId)
    {
        return _service.UpdateScheduleTimeSlot(dto, docId);
    }

    [HttpDelete]
    [Route("{docId}")]
    public Task DeleteScheduleTimeSlot([FromBody] ScheduleTimeSlotDTO dto, int docId)
    {
        return _service.DeleteScheduleTimeSlot(dto, docId);
    }
}