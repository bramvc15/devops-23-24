using Microsoft.AspNetCore.Mvc;
using Services.Core;
using Shared.DTO.Core;
using System.IdentityModel.Tokens.Jwt;
using System.Net;

namespace BlazorApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppointmentController : ControllerBase
{
    private readonly AppointmentService _service;

    public AppointmentController(AppointmentService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppointmentDTO>>> GetAppointments([FromHeader] string Authorization)
    {
        try
        {
            if (string.IsNullOrEmpty(Authorization))
            {
                return Unauthorized("JWT token is missing in Authorization header");
            }

            if (IsAuthorized(Authorization, "Employee"))
            {
                var appointments = await _service.GetAppointments();

                if (appointments == null)
                {
                    return NotFound();
                }

                return Ok(appointments);
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
    public async Task<ActionResult<AppointmentDTO>> CreateAppointment(int slotId, int patientId, string note, string reason, [FromHeader] string Authorization)
    {
        try
        {
            if (string.IsNullOrEmpty(Authorization))
            {
                return Unauthorized("JWT token is missing in Authorization header");
            }

            if (IsAuthorized(Authorization, "Employee"))
            {
                var appointment = _service.CreateAppointment(slotId, patientId, note, reason);

                if (appointment == null)
                {
                    return BadRequest();
                }

                return Ok(appointment);
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
    public async Task<ActionResult<AppointmentDTO>> UpdateAppointment([FromBody] AppointmentDTO appointment, [FromHeader] string Authorization)
    {
        try
        {
            if (string.IsNullOrEmpty(Authorization))
            {
                return Unauthorized("JWT token is missing in Authorization header");
            }

            if (IsAuthorized(Authorization, "Employee"))
            {
                var updatedAppointment = await _service.UpdateAppointment(appointment);

                if (updatedAppointment == null)
                {
                    return BadRequest();
                }

                return Ok(updatedAppointment);
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
    public async Task<ActionResult> DeleteAppointment([FromBody] AppointmentDTO appointment, [FromHeader] string Authorization)
    {
        try
        {
            if (string.IsNullOrEmpty(Authorization))
            {
                return Unauthorized("JWT token is missing in Authorization header");
            }

            if (IsAuthorized(Authorization, "Employee"))
            {
                await _service.DeleteAppointment(appointment);
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