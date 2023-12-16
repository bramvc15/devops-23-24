using Microsoft.AspNetCore.Mvc;
using Shared.DTO.Core;
using Services.Core;
using Microsoft.AspNetCore.Authorization;

namespace BlazorApp.Controllers.core;

[ApiController]
[Route("api/[controller]")]
// [Authorize]
public class DoctorController : ControllerBase
{
    private readonly DoctorService _service;

    public DoctorController(DoctorService service)
    {
        _service = service;
    }

    [HttpGet]
    public Task<IEnumerable<DoctorDTO>> GetDoctors()
    {
        return _service.GetDoctors();
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public Task<DoctorDTO> CreateDoctor([FromBody] DoctorDTO newDoc)
    {
        return _service.CreateDoctor(newDoc);
    }

    [HttpPut]
    [Authorize(Roles = "Admin")]
    public Task<DoctorDTO> UpdateDoctor([FromBody] DoctorDTO newDoc)
    {
        return _service.UpdateDoctor(newDoc);
    }

    [HttpDelete]
    [Authorize(Roles = "Admin")]
    public Task DeleteDoctor([FromBody] DoctorDTO docToDelete) 
    {
        return _service.DeleteDoctor(docToDelete);
    }
}