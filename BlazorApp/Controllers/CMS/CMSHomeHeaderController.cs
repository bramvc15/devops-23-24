using BlazorApp.Services;
using BlazorApp.Models;
using Microsoft.AspNetCore.Mvc;
using BlazorApp.Pages;

namespace BlazorApp.Controllers.CMS;

[ApiController]
[Route("[controller]")]
public class CMSHomeHeaderController : ControllerBase
{
    HomeHeaderService _service;

    public CMSHomeHeaderController(HomeHeaderService service)
    {
        _service = service;
    }

    // [HttpGet]
    // public async  Task<IEnumerable<HomeHeader>> GetContent()
    // {

    //     return await _service.GetContentAsync();

    // }

    [HttpGet]
    public async Task<IEnumerable<HomeHeader>> GetContent()
    {
        return await _service.GetContent();
    }

    [HttpPost]
    public void UpdateContent(string newTitle, string content)
    {
        _service.UpdateHeaderTitle(newTitle, content);
    }
}
