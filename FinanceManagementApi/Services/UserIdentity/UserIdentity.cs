using System.Security.Claims;

namespace FinanceManagementApi.Services.UserIdentity;

/// <summary>
/// Classe utilitária para gerenciar a identidade do usuário autenticado.
/// </summary>
public static class UserIdentity
{
    /// <summary>
    /// Obtém o ID do usuário autenticado a partir dos claims.
    /// </summary>
    /// <param name="user">O objeto <see cref="ClaimsPrincipal"/> representando o usuário autenticado.</param>
    /// <returns>O ID do usuário como um inteiro.</returns>
    /// <exception cref="Exception">Lançada se o ID do usuário não puder ser obtido.</exception>
    public static int GetUserId(ClaimsPrincipal user)
        => int.Parse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value 
            ?? throw new Exception("Não foi possível obter o id do usuário."));
}