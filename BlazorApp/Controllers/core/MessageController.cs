using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Core;
using Shared.DTO.Core;

namespace BlazorApp.Controllers.core;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class MessageController : ControllerBase
{
    private readonly MessageService _service;

    public MessageController(MessageService service)
    {
        _service = service;
    }

    [HttpGet]
    public Task<IEnumerable<MessageDTO>> GetMessages()
    {
        return _service.GetMessages();
    }

    [HttpPost]
    public Task<MessageDTO> CreateMessage([FromBody] MessageDTO request)
    {
        return _service.CreateMessage(request);
    }

    [HttpDelete]
    [Authorize(Roles = "Admin")]
    public Task DeleteMessage([FromBody] MessageDTO request)
    {
        return _service.DeleteMessage(request);
    }
}