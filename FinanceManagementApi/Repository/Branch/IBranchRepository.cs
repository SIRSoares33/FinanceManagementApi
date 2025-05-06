using FinanceManagementApi.Models.Branch;

namespace FinanceManagementApi.Repository.Branch
{
    /// <summary>
    /// Interface para gerenciar operações relacionadas a Branches no repositório.
    /// </summary>
    public interface IBranchRepository
    {
        /// <summary>
        /// Cria uma nova branch no repositório.
        /// </summary>
        /// <param name="branchModel">O modelo da branch a ser criada.</param>
        /// <returns>Uma tarefa representando a operação assíncrona.</returns>
        Task CreateBranchAsync(BranchModel branchModel);

        /// <summary>
        /// Exclui uma branch com base no ID fornecido.
        /// </summary>
        /// <param name="branchId">O ID da branch a ser excluída.</param>
        /// <returns>Uma tarefa representando a operação assíncrona.</returns>
        Task DeleteBranchAsync(int branchId);

        /// <summary>
        /// Atualiza uma branch existente com base no ID fornecido.
        /// </summary>
        /// <param name="branchId">O ID da branch a ser atualizada.</param>
        /// <param name="branchModel">O modelo atualizado da branch.</param>
        /// <returns>Uma tarefa representando a operação assíncrona.</returns>
        Task UpdateBranchAsync(int branchId, BranchModel branchModel);

        /// <summary>
        /// Obtém uma branch com base no ID fornecido.
        /// </summary>
        /// <param name="id">O ID da branch a ser obtida.</param>
        /// <returns>Uma tarefa que retorna o modelo da branch.</returns>
        Task<BranchModel> GetBranchByIdAsync(int id);

        /// <summary>
        /// Obtém todas as branches associadas a um usuário específico.
        /// </summary>
        /// <param name="userId">O ID do usuário.</param>
        /// <returns>Uma tarefa que retorna uma lista de branches.</returns>
        Task<List<BranchModel>> GetAllBranchsByUserIdAsync(int userId);
    }
}