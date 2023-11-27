using BlazorApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Controllers.CMS;

[ApiController]
[Route("[controller]")]
public class CMSBlogController : ControllerBase
{
    BlogService _service;

    public CMSBlogController(BlogService service)
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
