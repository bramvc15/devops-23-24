using Microsoft.AspNetCore.Mvc;
using BlazorApp.Services.CMS;
using Shared;

namespace BlazorApp.Controllers.CMS;

[ApiController]
[Route("[controller]")]
public class CMSLocationController : ControllerBase
{
    private readonly LocationService _service;

    public CMSLocationController(LocationService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<CMSLocation>> GetLocation()
    {
        return await _service.GetLocation();
    }

    [HttpPut]
    public async Task<CMSLocation> UpdateLocation(CMSLocation request)
    {
        return await _service.UpdateLocation(request);
    }
}
