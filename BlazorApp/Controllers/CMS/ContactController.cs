using Microsoft.AspNetCore.Mvc;
using Services.CMS;
using Shared;
using Shared.DTO.CMS;

namespace BlazorApp.Controllers.CMS;

[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    private readonly ContactService _service;

    public ContactController(ContactService service)
    {
        _service = service;
    }

    [HttpGet]
    public Task<ContactDTO> GetContact()
    {
        return _service.GetContact();
    }

    [HttpPut]
    public Task<ContactDTO> UpdateContact([FromBody] ContactDTO request)
    {
        return _service.UpdateContact(request);
    }
}
