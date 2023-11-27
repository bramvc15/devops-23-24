using BlazorApp.Services;
using BlazorApp.Models;
using Microsoft.AspNetCore.Mvc;
using BlazorApp.Pages;

namespace BlazorApp.Controllers.CMS;

[ApiController]
[Route("[controller]")]
public class CMSLocationController : ControllerBase
{
    LocationService _service;

    public CMSLocationController(LocationService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<LocationM>> GetContent()
    {
        return await _service.GetContent();
    }

    [HttpPost]
    public async Task UpdateLocationText(string content)
    {
        await _service.UpdateLocationText(content);
    }
}
