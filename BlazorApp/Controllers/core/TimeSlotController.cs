using Microsoft.AspNetCore.Mvc;
using Services.Core;
using Shared.DTO.Core;

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
    [Route("{docId}")]
    public Task<IEnumerable<TimeSlotDTO>> GetTimeSlots(int docId)
    {
        return _service.GetTimeSlots(docId);
    }

    [HttpPost]
    [Route("{docId}")]
    public Task<TimeSlotDTO> CreateTimeSlot([FromBody] TimeSlotDTO dto, int docId)
    {
        return _service.CreateTimeSlot(dto, docId);
    }
    
    [HttpPut]
    [Route("{docId}")]
    public Task<TimeSlotDTO> UpdateTimeSlot([FromBody] TimeSlotDTO dto, int docId)
    {
        return _service.UpdateTimeSlot(dto, docId);
    }

    [HttpDelete]
    [Route("{docId}")]
    public Task DeleteTimeSlot([FromBody] TimeSlotDTO dto, int docId)
    {
        return _service.DeleteTimeSlot(dto, docId);
    }
}