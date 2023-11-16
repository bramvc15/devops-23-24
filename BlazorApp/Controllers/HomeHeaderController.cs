using BlazorApp.Services;
using BlazorApp.Models;
using BlazorApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using BlazorApp.Pages;

namespace BlazorApp.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeHeaderController : ControllerBase
{
    HomeHeaderService _service;

    public HomeHeaderController(HomeHeaderService service)
    {
        _service = service;
    }

    // [HttpGet]
    // public async  Task<IEnumerable<HomeHeader>> GetContent()
    // {

    //     return await _service.GetContentAsync();

    // }

    [HttpGet]
    public IEnumerable<HomeHeader> GetContent()
    {

        return _service.GetContent();

    }

    [HttpPost]
    public void UpdateContent(string newTitle, string content)
    {
        _service.UpdateHeaderTitle(newTitle, content);
    }
}
