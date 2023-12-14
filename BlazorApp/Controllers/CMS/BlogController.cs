using Services.CMS;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.DTO.CMS;
using Microsoft.AspNetCore.Authorization;

namespace BlazorApp.Controllers.CMS;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class BlogController : ControllerBase
{
    private readonly BlogService _service;

    public BlogController(BlogService service)
    {
        _service = service;
    }

    [HttpGet]
    public Task<IEnumerable<BlogDTO>> GetBlogs()
    {
        return _service.GetBlogs();
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public Task<BlogDTO> CreateBlog([FromBody] BlogDTO request)
    {
        return _service.CreateBlog(request);
    }

    [HttpPut]
    [Authorize(Roles = "Admin")]
    public Task<BlogDTO> UpdateBlog([FromBody] BlogDTO request)
    {
        return _service.UpdateBlog(request);
    }

    [HttpDelete]
    [Authorize(Roles = "Admin")]
    public Task DeleteBlog([FromBody] BlogDTO request)
    {
        return _service.DeleteBlog(request);
    }
}
