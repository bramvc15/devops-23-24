using BlazorApp.Services;
using BlazorApp.Models;
using BlazorApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using BlazorApp.Pages;

namespace BlazorApp.Controllers;

[ApiController]
[Route("[controller]")]
public class ContactController : ControllerBase
{
   ContactService _service;

    public ContactController(ContactService service)
    {
        _service = service;
    }


    [HttpGet]
    public IEnumerable<ContactM> GetContent()
    {

        return _service.GetContent();

    }

    [HttpPost]
    public void UpdateContent( string content)
    {
        _service.UpdateContactText(content);
    }
}
