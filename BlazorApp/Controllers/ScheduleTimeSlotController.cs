using BlazorApp.Services;
using BlazorApp.Models;
using BlazorApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using BlazorApp.Pages;

namespace BlazorApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ScheduleTimeSlotController : ControllerBase
{
    ScheduleTimeSlotService _service;

    public ScheduleTimeSlotController(ScheduleTimeSlotService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("getScheduleTimeSlots")]
    public async Task<IEnumerable<ScheduleTimeSlot>> GetContent()
    {
        return await _service.GetContent();
    }

    [HttpPost]
    [Route("updateScheduleTimeSlot")]
    public void UpdateContent(int Id, int Doctor_Id, string ScheduleGroup, DateTime Date, int Duration)
    {
        _service.UpdateScheduleTimeSlot(Id, Doctor_Id, ScheduleGroup, Date, Duration);
    }
}