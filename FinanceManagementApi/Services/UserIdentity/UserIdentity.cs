using System.Security.Claims;

namespace FinanceManagementApi.Services.UserIdentity
{
    public static class UserIdentity
    {
        public static int GetUserId(ClaimsPrincipal user)
            => int.Parse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value 
                ?? throw new Exception("Não foi possível obter o id do usuário."));
    }
}