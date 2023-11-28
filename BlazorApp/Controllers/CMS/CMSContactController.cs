using Microsoft.AspNetCore.Mvc;
using BlazorApp.Services.CMS;
using Shared;

namespace BlazorApp.Controllers.CMS;

[ApiController]
[Route("[controller]")]
public class CMSContactController : ControllerBase
{
    private readonly CMSContactService _service;

    public CMSContactController(CMSContactService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<CMSContact>> GetContact()
    {
        return await _service.GetContact();
    }

    [HttpPut]
    public async Task<CMSContact> UpdateContact([FromBody] CMSContact request)
    {
        return await _service.UpdateContact(request);
    }
}
