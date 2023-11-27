using BlazorApp.Services;
using BlazorApp.Models;
using Microsoft.AspNetCore.Mvc;
using BlazorApp.Pages;

namespace BlazorApp.Controllers.CMS;

[ApiController]
[Route("[controller]")]
public class CMSTreatmentController : ControllerBase
{
    TreatmentService _service;

    public CMSTreatmentController(TreatmentService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<Treatment>> GetContent()
    {
        return await _service.GetContent();
    }

    // moet dit niet HttpPut ??
    [HttpPost]
    public async Task UpdateTreatment(int id, string newName, string newDescription, string newImage)
    {
        await _service.UpdateTreatment(id, newName, newDescription, newImage);
    }
}
