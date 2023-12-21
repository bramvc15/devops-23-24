using Microsoft.AspNetCore.Mvc;
using Shared.DTO.Core;
using Services.Core;
using System.IdentityModel.Tokens.Jwt;

namespace BlazorApp.Controllers;

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
    public async Task<ActionResult<IEnumerable<DoctorDTO>>> GetDoctors([FromHeader] string Authorization)
    {
        try
        {
            if (string.IsNullOrEmpty(Authorization))
            {
                return Unauthorized("JWT token is missing in Authorization header");
            }

            if (IsAuthorized(Authorization, "Employee"))
            {
                var doctors = await _service.GetDoctors();

                if (doctors == null)
                {
                    return NotFound();
                }

                return Ok(doctors);
            } 
            else
            {
                return Unauthorized("User is not authorized to access this resource");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost]
    public async Task<ActionResult<DoctorDTO>> CreateDoctor([FromBody] DoctorDTO newDoc, [FromHeader] string Authorization)
    {
        try
        {
            if (string.IsNullOrEmpty(Authorization))
            {
                return Unauthorized("JWT token is missing in Authorization header");
            }

            if (IsAuthorized(Authorization, "Admin"))
            {
                var doctor = await _service.CreateDoctor(newDoc);

                if (doctor == null)
                {
                    return BadRequest();
                }

                return Ok(doctor);
            }
            else
            {
                return Unauthorized("User is not authorized to access this resource");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPut]
    public async Task<ActionResult<DoctorDTO>> UpdateDoctor([FromBody] DoctorDTO newDoc, [FromHeader] string Authorization)
    {
        try
        {
            if (string.IsNullOrEmpty(Authorization))
            {
                return Unauthorized("JWT token is missing in Authorization header");
            }

            if (IsAuthorized(Authorization, "Admin"))
            {
                var doctor = await _service.UpdateDoctor(newDoc);

                if (doctor == null)
                {
                    return BadRequest();
                }

                return Ok(doctor);
            }
            else
            {
                return Unauthorized("User is not authorized to access this resource");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteDoctor([FromBody] DoctorDTO docToDelete, [FromHeader] string Authorization)
    {
        try
        {
            if (string.IsNullOrEmpty(Authorization))
            {
                return Unauthorized("JWT token is missing in Authorization header");
            }

            if (IsAuthorized(Authorization, "Admin"))
            {
                await _service.DeleteDoctor(docToDelete);
                return Ok();
            }
            else
            {
                return Unauthorized("User is not authorized to access this resource");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "Internal server error");
        }
    }

    private static bool IsAuthorized(string jwtToken, string checkRole)
    {
        try
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwtToken) as JwtSecurityToken;

            if (jsonToken == null)
            {
                return false;
            }

            var roleClaims = jsonToken.Claims.Where(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role")?.Select(c => c.Value);
            var concatenatedRoles = string.Join(",", roleClaims);
            if (roleClaims != null && concatenatedRoles.Contains(checkRole, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }
        catch (Exception ex)
        {
            return false;
        }
        return false;
    }
}