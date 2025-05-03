using System.Security.Claims;
using FinanceManagementApi.Models.Login;
using FinanceManagementApi.Models.User;
using FinanceManagementApi.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManagementApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController(IAuthService service) : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginModel model)
        {
            var JwtToken = await service.LoginAsync(model);

            return JwtToken is null ? Unauthorized("Usuário não encontrado.")
            : Ok(JwtToken);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] UserModel model)
        {
            try
            {
                await service.RegisterAsync(model);
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
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? 
                    throw new Exception("Não foi possível obter o id do usuário.");
                
                await service.DeleteAsync(int.Parse(userId));
                
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}