using Microsoft.AspNetCore.Mvc;
using Services.Core;
using Shared.DTO.Core;
using System.IdentityModel.Tokens.Jwt;

namespace BlazorApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController : ControllerBase
{
    private readonly PatientService _service;

    public PatientController(PatientService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PatientDTO>>> GetPatients([FromHeader] string Authorization)
    {
        try
        {
            if (string.IsNullOrEmpty(Authorization))
            {
                return Unauthorized("JWT token is missing in Authorization header");
            }

            if (IsAuthorized(Authorization, "Employee"))
            {
                var patients = await _service.GetPatients();

                if (patients == null)
                {
                    return NotFound();
                }

                return Ok(patients);
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