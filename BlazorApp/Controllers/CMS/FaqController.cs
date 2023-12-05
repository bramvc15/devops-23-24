using Microsoft.AspNetCore.Mvc;
using BlazorApp.Pages;
using Shared;
using Services.CMS;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;
using Shared.DTO.CMS;

namespace BlazorApp.Controllers.CMS;

[ApiController]
[Route("api/[controller]")]
public class FaqController : ControllerBase
{
    private readonly FaqService _service;

    public FaqController(FaqService service)
    {
        _service = service;
    }

    [HttpGet]
    public Task<IEnumerable<FaqDTO>> GetFaqs()
    {
        return _service.GetFaqs();
    }

    [HttpPost]
    public Task<FaqDTO> CreateFaq([FromBody] FaqDTO request)
    {
        return _service.CreateFaq(request);
    }

    [HttpPut]
    public Task<FaqDTO> UpdateFaq([FromBody] FaqDTO request)
    {
        return _service.UpdateFaq(request);
    }

    [HttpDelete]
    public Task DeleteFaq([FromBody] FaqDTO request)
    {
        return _service.DeleteFaq(request);
    }
}