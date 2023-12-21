using Microsoft.AspNetCore.Mvc;
using Services.CMS;
using Shared.DTO.CMS;
using System.IdentityModel.Tokens.Jwt;
using System.Net;

namespace BlazorApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NoteController : ControllerBase
{
    private readonly NoteService _service;

    public NoteController(NoteService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<NoteDTO>>> GetNotes([FromHeader] string Authorization)
    {
        try
        {
            if (string.IsNullOrEmpty(Authorization))
            {
                return Unauthorized("JWT token is missing in Authorization header");
            }

            if (IsAuthorized(Authorization, "Employee"))
            {
                var notes = await _service.GetNotes();

                if (notes == null)
                {
                    return NotFound();
                }

                return Ok(notes);
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
    public async Task<ActionResult<NoteDTO>> CreateNote([FromBody] NoteDTO request, [FromHeader] string Authorization)
    {
        try
        {
            if (string.IsNullOrEmpty(Authorization))
            {
                return Unauthorized("JWT token is missing in Authorization header");
            }

            if (IsAuthorized(Authorization, "Employee"))
            {
                var note = await _service.CreateNote(request);

                if (note == null)
                {
                    return BadRequest();
                }

                return Ok(note);
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
    public async Task<ActionResult<NoteDTO>> UpdateNote([FromBody] NoteDTO request, [FromHeader] string Authorization)
    {
        try
        {
            if (string.IsNullOrEmpty(Authorization))
            {
                return Unauthorized("JWT token is missing in Authorization header");
            }

            if (IsAuthorized(Authorization, "Employee"))
            {
                var note = await _service.UpdateNote(request);

                if (note == null)
                {
                    return BadRequest();
                }

                return Ok(note);
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
    public async Task<ActionResult> DeleteNote([FromBody] NoteDTO request, [FromHeader] string Authorization)
    {
        try
        {
            if (string.IsNullOrEmpty(Authorization))
            {
                return Unauthorized("JWT token is missing in Authorization header");
            }

            if (IsAuthorized(Authorization, "Employee"))
            {
                await _service.DeleteNote(request);
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