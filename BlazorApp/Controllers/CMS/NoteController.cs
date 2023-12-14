using Microsoft.AspNetCore.Mvc;
using BlazorApp.Pages;
using Shared;
using Services.CMS;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;
using Shared.DTO.CMS;
using Microsoft.AspNetCore.Authorization;

namespace BlazorApp.Controllers.CMS;

[ApiController]
[Route("api/[controller]")]
// [Authorize]
public class NoteController : ControllerBase
{
    private readonly NoteService _service;

    public NoteController(NoteService service)
    {
        _service = service;
    }

    [HttpGet]
    public Task<IEnumerable<NoteDTO>> GetNotes()
    {
        return _service.GetNotes();
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public Task<NoteDTO> CreateNote([FromBody] NoteDTO request)
    {
        return _service.CreateNote(request);
    }

    [HttpPut]
    [Authorize(Roles = "Admin")]
    public Task<NoteDTO> UpdateNote([FromBody] NoteDTO request)
    {
        return _service.UpdateNote(request);
    }

    [HttpDelete]
    [Authorize(Roles = "Admin")]
    public Task DeleteNote([FromBody] NoteDTO request)
    {
        return _service.DeleteNote(request);
    }
}