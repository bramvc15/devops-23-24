using BlazorApp.Models;
using Microsoft.AspNetCore.Mvc;
using BlazorApp.Pages;
using Shared;
using BlazorApp.Services.CMS;

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
    public async Task<IEnumerable<CMSLocation>> GetContent()
    {
        return await _service.GetContent();
    }

    [HttpPost]
    public async Task UpdateLocationText(CMSLocation request)
    {
        await _service.UpdateLocationText(request);
    }
}
