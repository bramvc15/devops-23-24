using BlazorApp.Models;
using Microsoft.AspNetCore.Mvc;
using BlazorApp.Pages;
using Shared;
using BlazorApp.Services.CMS;

namespace BlazorApp.Controllers.CMS;

[ApiController]
[Route("[controller]")]
public class CMSContactController : ControllerBase
{
    private readonly CMSContactService _service;

    public CMSContactController(CMSContactService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<CMSContact>> GetContent()
    {
        return await _service.GetContent();
    }

    [HttpPost]
    public async Task UpdateContactText(CMSContact request)
    {
        await _service.UpdateContactText(request);
    }
}
