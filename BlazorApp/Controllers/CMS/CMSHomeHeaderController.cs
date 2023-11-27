using BlazorApp.Models;
using Microsoft.AspNetCore.Mvc;
using BlazorApp.Pages;
using Shared;
using BlazorApp.Services.CMS;

namespace BlazorApp.Controllers.CMS;

[ApiController]
[Route("[controller]")]
public class CMSHomeHeaderController : ControllerBase
{
    private readonly CMSHomeHeaderService _service;

    public CMSHomeHeaderController(CMSHomeHeaderService service)
    {
        _service = service;
    }

    // [HttpGet]
    // public async  Task<IEnumerable<HomeHeader>> GetContent()
    // {

    //     return await _service.GetContentAsync();

    // }

    [HttpGet]
    public async Task<IEnumerable<CMSHomeHeader>> GetContent()
    {
        return await _service.GetContent();
    }

    [HttpPost]
    public void UpdateContent(CMSHomeHeader request)
    {
        _service.UpdateHeaderTitle(request);
    }
}
