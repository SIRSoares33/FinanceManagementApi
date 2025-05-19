using AutoMapper;
using Finance.Dtos;
using FinanceManagementApi.Context.Tables;
using FinanceManagementApi.Services.Auth;
using FinanceManagementApi.Services.UserIdentity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManagementApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController(IAuthService service, IMapper mapper) : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto model)
        {
            var JwtToken = await service.LoginAsync(mapper.Map<UserTable>(model));

            return JwtToken is null ? Unauthorized("Usuário não encontrado.")
            : Ok(JwtToken);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDto model)
        {
            try
            {
                await service.RegisterAsync(mapper.Map<UserTable>(model));
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
                var userId = UserIdentity.GetUserId(User);
                
                await service.DeleteAsync(userId);
                
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}