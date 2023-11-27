using BlazorApp.Services.CMS;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace BlazorApp.Controllers.CMS;

[ApiController]
[Route("api/[controller]")]
public class CMSBlogController : ControllerBase
{
    private readonly CMSBlogService _service;

    public CMSBlogController(CMSBlogService service)
    {
        _service = service;
    }

    [HttpGet]
    public Task<IEnumerable<CMSBlog>> GetBlogs()
    {
        return _service.GetBlogs();
    }

    [HttpPost]
    public Task<CMSBlog> CreateBlog([FromBody] CMSBlog request)
    {
        return _service.CreateBlog(request);
    }

    [HttpPut]
    public Task<CMSBlog> UpdateBlog([FromBody] CMSBlog request)
    {
        return _service.UpdateBlog(request);
    }

    [HttpDelete]
    public Task DeleteBlog([FromBody] CMSBlog request)
    {
        return _service.DeleteBlog(request);
    }
}
