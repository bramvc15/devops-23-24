using BlazorApp.Services;
using BlazorApp.Models;
using BlazorApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using BlazorApp.Pages;

namespace BlazorApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
   ContactService _service;

    public ContactController(ContactService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<ContactM>> GetContent()
    {
        return await _service.GetContent();
    }

    [HttpPost]
    public async Task UpdateContactText( string content)
    {
        await _service.UpdateContactText(content);
    }
}
