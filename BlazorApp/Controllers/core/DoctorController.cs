using Microsoft.AspNetCore.Mvc;
using Shared.DTO.Core;
using Services.Core;

namespace BlazorApp.Controllers.core;

[ApiController]
[Route("api/[controller]")]
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
    public Task<DoctorDTO> CreateDoctor([FromBody] DoctorDTO newDoc)
    {
        return _service.CreateDoctor(newDoc);
    }

    [HttpPut]
    public Task<DoctorDTO> UpdateDoctor([FromBody] DoctorDTO newDoc)
    {
        return _service.UpdateDoctor(newDoc);
    }

    [HttpDelete]
    public Task DeleteDoctor([FromBody] DoctorDTO docToDelete) 
    {
        return _service.DeleteDoctor(docToDelete);
    }
}