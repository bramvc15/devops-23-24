using Microsoft.AspNetCore.Mvc;
using BlazorApp.Services.CMS;
using Shared;

namespace BlazorApp.Controllers.CMS;

[ApiController]
[Route("api/[controller]")]
public class CMSHomeHeaderController : ControllerBase
{
    private readonly CMSHomeHeaderService _service;

    public CMSHomeHeaderController(CMSHomeHeaderService service)
    {
        _service = service;
    }

    [HttpGet]
    public Task<CMSHomeHeader> GetHomeHeader()
    {
        return _service.GetHomeHeader();
    }

    [HttpPut]
    public async Task<CMSHomeHeader> UpdateHomeHeader([FromBody] CMSHomeHeader request)
    {
        return await _service.UpdateHomeHeader(request);
    }
}
