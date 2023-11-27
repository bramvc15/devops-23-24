using BlazorApp.Services;
using BlazorApp.Models;
using BlazorApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using BlazorApp.Pages;

namespace BlazorApp.Controllers;

[ApiController]
[Route("[controller]")]
public class TreatmentController : ControllerBase
{
    TreatmentService _service;

    public TreatmentController(TreatmentService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<Treatment>> GetContent()
    {
        return await _service.GetContent();
    }

    [HttpPost]
    public void UpdateContent(int id, string newName, string newDescription, string newImage)
    {
        _service.UpdateTreatment(id, newName, newDescription, newImage);
    }
}
