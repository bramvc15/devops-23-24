using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.CMS;
using Shared;
using Shared.DTO.CMS;

namespace BlazorApp.Controllers.CMS;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class HomeHeaderController : ControllerBase
{
    private readonly HomeHeaderService _service;

    public HomeHeaderController(HomeHeaderService service)
    {
        _service = service;
    }

    [HttpGet]
    public Task<HomeHeaderDTO> GetHomeHeader()
    {
        return _service.GetHomeHeader();
    }

    [HttpPut]
    [Authorize(Roles = "Admin")]
    public async Task<HomeHeaderDTO> UpdateHomeHeader([FromBody] HomeHeaderDTO request)
    {
        return await _service.UpdateHomeHeader(request);
    }
}
