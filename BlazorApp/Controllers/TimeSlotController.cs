using Microsoft.AspNetCore.Mvc;
using Services.Core;
using Shared.DTO.Core;
using System.IdentityModel.Tokens.Jwt;
using System.Net;

namespace BlazorApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TimeSlotController : ControllerBase
{
    private readonly TimeSlotService _service;

    public TimeSlotController(TimeSlotService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("{docId}")]
    public async Task<ActionResult<IEnumerable<TimeSlotDTO>>> GetTimeSlots(int docId, [FromHeader] string Authorization)
    {
        try
        {
            if (string.IsNullOrEmpty(Authorization))
            {
                return Unauthorized("JWT token is missing in Authorization header");
            }

            if (IsAuthorized(Authorization, "Employee"))
            {
                var timeSlots = await _service.GetTimeSlots(docId);

                if (timeSlots == null)
                {
                    return NotFound();
                }

                return Ok(timeSlots);
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
    [Route("{docId}")]
    public async Task<ActionResult<TimeSlotDTO>> CreateTimeSlot([FromBody] TimeSlotDTO dto, int docId, [FromHeader] string Authorization)
    {
        try
        {
            if (string.IsNullOrEmpty(Authorization))
            {
                return Unauthorized("JWT token is missing in Authorization header");
            }

            if (IsAuthorized(Authorization, "Employee"))
            {
                var timeSlot = await _service.CreateTimeSlot(dto, docId);

                if (timeSlot == null)
                {
                    return BadRequest();
                }

                return Ok(timeSlot);
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
    [Route("{docId}")]
    public async Task<ActionResult<TimeSlotDTO>> UpdateTimeSlot([FromBody] TimeSlotDTO dto, int docId, [FromHeader] string Authorization)
    {
        try
        {
            if (string.IsNullOrEmpty(Authorization))
            {
                return Unauthorized("JWT token is missing in Authorization header");
            }

            if (IsAuthorized(Authorization, "Employee"))
            {
                var timeSlot = await _service.UpdateTimeSlot(dto, docId);

                if (timeSlot == null)
                {
                    return BadRequest();
                }

                return Ok(timeSlot);
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
    [Route("{docId}")]
    public async Task<ActionResult> DeleteTimeSlot([FromBody] TimeSlotDTO dto, int docId, [FromHeader] string Authorization)
    {
        try
        {
            if (string.IsNullOrEmpty(Authorization))
            {
                return Unauthorized("JWT token is missing in Authorization header");
            }

            if (IsAuthorized(Authorization, "Employee"))
            {
                await _service.DeleteTimeSlot(dto, docId);
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