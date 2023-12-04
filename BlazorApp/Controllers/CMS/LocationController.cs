using Microsoft.AspNetCore.Mvc;
using Services.CMS;
using Shared;
using Shared.DTO.CMS;

namespace BlazorApp.Controllers.CMS;

[ApiController]
[Route("api/[controller]")]
public class LocationController : ControllerBase
{
    private readonly LocationService _service;

    public LocationController(LocationService service)
    {
        _service = service;
    }

    [HttpGet]
    public Task<LocationDTO> GetLocation()
    {
        return _service.GetLocation();
    }
    
    [HttpPut]
    public Task<LocationDTO> UpdateLocation([FromBody] LocationDTO request)
    {
        return _service.UpdateLocation(request);
    }
}
