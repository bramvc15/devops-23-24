using BlazorApp.Services;
using BlazorApp.Models;
using BlazorApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using BlazorApp.Pages;

namespace BlazorApp.Controllers;

[ApiController]
[Route("[controller]")]
public class BlogController : ControllerBase
{
    BlogService _service;

    public BlogController(BlogService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<(IEnumerable<Blog>, int totalPages)> GetContent()
    {
        return await _service.GetContent();
    }

    [HttpPost]
     public async Task AddBlog(string newTitle, string newText, string newImage)
    {
        await _service.AddBlog(newTitle, newText, newImage);
     }

    // [HttpPost]
    // public void UpdateBlog(int id, string newTitle, string content)
    // {
    //     _service.UpdateBlog(int id ,string newTitle, string content)
    // }
}
