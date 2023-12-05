using Services.CMS;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.DTO.CMS;

namespace BlazorApp.Controllers.CMS;

[ApiController]
[Route("api/[controller]")]
public class BlogController : ControllerBase
{
    private readonly BlogService _service;

    public BlogController(BlogService service)
    {
        _service = service;
    }

    [HttpGet("{page}, {pageSize}")]
    public Task<IEnumerable<BlogDTO>> GetBlogs(int page, int pageSize)
    {
        return _service.GetBlogs(page, pageSize);
    }

    [HttpGet("{blogId}")]
    public Task<BlogDTO> GetBlogById(int blogId) 
    {
        return _service.GetBlog(blogId);
    }

    [HttpPost]
    public Task<BlogDTO> CreateBlog([FromBody] BlogDTO request)
    {
        return _service.CreateBlog(request);
    }

    [HttpPut]
    public Task<BlogDTO> UpdateBlog([FromBody] BlogDTO request)
    {
        return _service.UpdateBlog(request);
    }

    [HttpDelete("{blogId}")]
    public Task DeleteBlog(int blogId)
    {
        return _service.DeleteBlog(blogId);
    }
}
