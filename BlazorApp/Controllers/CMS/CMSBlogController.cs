using BlazorApp.Services.CMS;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace BlazorApp.Controllers.CMS;

[ApiController]
[Route("[controller]")]
public class CMSBlogController : ControllerBase
{
    private readonly BlogService _service;

    public CMSBlogController(BlogService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<(IEnumerable<CMSBlog>, int totalPages)> GetContent()
    {
        return await _service.GetContent();
    }

    [HttpPost]
    public async Task AddBlog(CMSBlog request)
    {
        await _service.AddBlog(request);
    }

    // [HttpPost]
    // public void UpdateBlog(int id, string newTitle, string content)
    // {
    //     _service.UpdateBlog(int id ,string newTitle, string content)
    // }
}
