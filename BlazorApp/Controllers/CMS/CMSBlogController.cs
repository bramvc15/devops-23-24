using BlazorApp.Services.CMS;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace BlazorApp.Controllers.CMS;

[ApiController]
[Route("[controller]")]
public class CMSBlogController : ControllerBase
{
    private readonly CMSBlogService _service;

    public CMSBlogController(CMSBlogService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<CMSBlog>> GetBlogs()
    {
        return await _service.GetBlogs();
    }

    [HttpPost]
    public async Task<CMSBlog> CreateBlog([FromBody] CMSBlog request)
    {
        return await _service.CreateBlog(request);
    }

    [HttpPut]
    public async Task<CMSBlog> UpdateBlog([FromBody] CMSBlog request)
    {
        return await _service.UpdateBlog(request);
    }

    [HttpDelete]
    public async Task<CMSBlog> DeleteBlog([FromBody] CMSBlog request)
    {
        return await _service.DeleteBlog(request);
    }
}
