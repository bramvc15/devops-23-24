using BlazorApp.Services;
using BlazorApp.Models;
using BlazorApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using BlazorApp.Pages;

namespace BlazorApp.Controllers;

[ApiController]
[Route("[controller]")]
public class LocationController : ControllerBase
{
    LocationService _service;

    public LocationController(LocationService service)
    {
        _service = service;
    }


    [HttpGet]
    public IEnumerable<LocationM> GetContent()
    {

        return _service.GetContent();

    }

    [HttpPost]
    public void UpdateContent( string content)
    {
        _service.UpdateLocationText(content);
    }
}
