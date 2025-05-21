using Finance.Dtos;
using FinanceManagementApi.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManagementApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(IAuthService service) : ControllerBase
{
    [HttpPost("Login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginDto dto)
    {
        var JwtToken = await service.LoginAsync(dto);

        return JwtToken is null ? Unauthorized("Usuário não encontrado.")
        : Ok(JwtToken);
    }
    [HttpPost("Register")]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterDto dto)
    {
        try
        {
            await service.RegisterAsync(dto);
            return Created();
        }
        catch(Exception ex)
        {
            return UnprocessableEntity(ex.Message);
        }
    }
    [HttpDelete("Delete")]
    [Authorize]
    public async Task<IActionResult> DeleteAsync()
    {
        try
        {
            await service.DeleteAsync(User);
            return Ok();
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}