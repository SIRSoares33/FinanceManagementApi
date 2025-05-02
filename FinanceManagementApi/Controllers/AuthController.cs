using FinanceManagementApi.Models.Login;
using FinanceManagementApi.Repository.User;
using FinanceManagementApi.Services.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManagementApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController(IUserRepository repository, ITokenService tokenService) : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginModel model)
        {
            var user = await repository.Login(model);

            return user is null ? Unauthorized("Usuário não encontrado.")
            : Ok(tokenService.GenerateToken(user));
        }
        [Authorize]
        [HttpGet("Get")]
        public IActionResult GetAction() => Ok();
    }
}