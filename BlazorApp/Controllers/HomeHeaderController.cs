using BlazorApp.Services;
using BlazorApp.Models;
using BlazorApp.Controllers;
using Microsoft.AspNetCore.Mvc;

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

    public IEnumerable<HomeHeader> GetContent()
    {

        return _service.GetContent();

    }

    public void UpdateContent(int HeaderId, string newTitle)
    {
        _service.UpdateHeaderTitle(HeaderId, newTitle);
    }
}
