using Microsoft.AspNetCore.Mvc;
using Services.CMS;
using Shared;

namespace BlazorApp.Controllers.CMS;

[ApiController]
[Route("api/[controller]")]
public class CMSContactController : ControllerBase
{
    private readonly CMSContactService _service;

    public CMSContactController(CMSContactService service)
    {
        _service = service;
    }

    [HttpGet]
    public Task<CMSContact> GetContact()
    {
        return _service.GetContact();
    }

    [HttpPut]
    public Task<CMSContact> UpdateContact([FromBody] CMSContact request)
    {
        return _service.UpdateContact(request);
    }
}
