using Microsoft.AspNetCore.Mvc;
using BlazorApp.Services.CMS;
using Shared;

namespace BlazorApp.Controllers.CMS;

[ApiController]
[Route("api/[controller]")]
public class CMSLocationController : ControllerBase
{
    private readonly CMSLocationService _service;

    public CMSLocationController(CMSLocationService service)
    {
        _service = service;
    }

    [HttpGet]
    public Task<CMSLocation> GetLocation()
    {
        return _service.GetLocation();
    }
    
    [HttpPut]
    public Task<CMSLocation> UpdateLocation([FromBody] CMSLocation request)
    {
        return _service.UpdateLocation(request);
    }
}
