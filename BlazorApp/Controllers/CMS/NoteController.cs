using Microsoft.AspNetCore.Mvc;
using Services.CMS;
using Shared.DTO.CMS;

namespace BlazorApp.Controllers.CMS;

[ApiController]
[Route("api/[controller]")]
public class NoteController : ControllerBase
{
    private readonly NoteService _service;

    public NoteController(NoteService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<NoteDTO>>> GetNotes()
    {
        try
        {
            var notes = await _service.GetNotes();

            if (notes == null)
            {
                return NotFound();
            }

            return Ok(notes);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost]
    public async Task<ActionResult<NoteDTO>> CreateNote([FromBody] NoteDTO request)
    {
        try
        {
            var note = await _service.CreateNote(request);

            if (note == null)
            {
                return BadRequest();
            }

            return Ok(note);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPut]
    public async Task<ActionResult<NoteDTO>> UpdateNote([FromBody] NoteDTO request)
    {
        try
        {
            var note = await _service.UpdateNote(request);

            if (note == null)
            {
                return BadRequest();
            }

            return Ok(note);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteNote([FromBody] NoteDTO request)
    {
        try
        {
            await _service.DeleteNote(request);
            return Ok();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "Internal server error");
        }
    }
}