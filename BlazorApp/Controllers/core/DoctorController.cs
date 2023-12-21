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
    public async Task<ActionResult<IEnumerable<DoctorDTO>>> GetDoctors()
    {
        try
        {
            var doctors = await _service.GetDoctors();

            if (doctors == null)
            {
                return NotFound();
            }

            return Ok(doctors);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost]
    public async Task<ActionResult<DoctorDTO>> CreateDoctor([FromBody] DoctorDTO newDoc)
    {
        try
        {
            var doctor = await _service.CreateDoctor(newDoc);
            
            if (doctor == null)
            {
                return BadRequest();
            }

            return Ok(doctor);

        } catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPut]
    public async Task<ActionResult<DoctorDTO>> UpdateDoctor([FromBody] DoctorDTO newDoc)
    {
        try
        {
            var doctor = await _service.UpdateDoctor(newDoc);

            if (doctor == null)
            {
                return BadRequest();
            }

            return Ok(doctor);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteDoctor([FromBody] DoctorDTO docToDelete) 
    {
        try
        {
            await _service.DeleteDoctor(docToDelete);
            return Ok();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "Internal server error");
        }
    }
}