using BlazorApp.Services;
using BlazorApp.Models;
using Microsoft.AspNetCore.Mvc;
using BlazorApp.Pages;

namespace BlazorApp.Controllers.CMS;

[ApiController]
[Route("[controller]")]
public class CMSContactController : ControllerBase
{
    ContactService _service;

    public CMSContactController(ContactService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<ContactM>> GetContent()
    {
        return await _service.GetContent();
    }

    [HttpPost]
    public async Task UpdateContactText(string content)
    {
        await _service.UpdateContactText(content);
    }
}
