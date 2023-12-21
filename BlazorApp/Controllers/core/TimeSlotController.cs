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
    public async Task<ActionResult<IEnumerable<TimeSlotDTO>>> GetTimeSlots(int docId)
    {
        try
        {
            var timeSlots = await _service.GetTimeSlots(docId);

            if (timeSlots == null)
            {
                return NotFound();
            }

            return Ok(timeSlots);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost]
    [Route("{docId}")]
    public async Task<ActionResult<TimeSlotDTO>> CreateTimeSlot([FromBody] TimeSlotDTO dto, int docId)
    {
        try
        {
            var timeSlot = await _service.CreateTimeSlot(dto, docId);

            if (timeSlot == null)
            {
                return BadRequest();
            }

            return Ok(timeSlot);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "Internal server error");
        }
    }
    
    [HttpPut]
    [Route("{docId}")]
    public async Task<ActionResult<TimeSlotDTO>> UpdateTimeSlot([FromBody] TimeSlotDTO dto, int docId)
    {
        try
        {
            var timeSlot = await _service.UpdateTimeSlot(dto, docId);

            if (timeSlot == null)
            {
                return BadRequest();
            }

            return Ok(timeSlot);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpDelete]
    [Route("{docId}")]
    public async Task<ActionResult> DeleteTimeSlot([FromBody] TimeSlotDTO dto, int docId)
    {
        try
        {
            await _service.DeleteTimeSlot(dto, docId);
            return Ok();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "Internal server error");
        }
    }
}