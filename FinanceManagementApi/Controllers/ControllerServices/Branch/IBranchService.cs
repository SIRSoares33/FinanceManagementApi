using System.Security.Claims;
using Finance.Dtos;

namespace FinanceManagementApi.Controllers.ControllerServices.Branch
{
    /// <summary>
    /// Interface que define os serviços relacionados às operações com filiais (branches).
    /// Responsável por fornecer métodos para criação, listagem e exclusão de filiais de um usuário autenticado.
    /// </summary>
    public interface IBranchService
    {
        /// <summary>
        /// Obtém todas as filiais associadas ao usuário autenticado.
        /// </summary>
        /// <param name="User">Usuário autenticado (ClaimsPrincipal).</param>
        /// <returns>Lista de <see cref="BranchDto"/> representando as filiais do usuário.</returns>
        Task<List<BranchDto>> GetAllBranchsByUserIdAsync(ClaimsPrincipal User);

        /// <summary>
        /// Cria uma nova filial associada ao usuário autenticado.
        /// </summary>
        /// <param name="dto">Objeto contendo os dados da filial a ser criada.</param>
        /// <param name="user">Usuário autenticado (ClaimsPrincipal).</param>
        Task CreateBranchAsync(BranchDto dto, ClaimsPrincipal user);

        /// <summary>
        /// Exclui uma filial com base no seu identificador.
        /// </summary>
        /// <param name="id">Identificador da filial a ser excluída.</param>
        Task DeleteBranchAsync(int id);
    }
}
