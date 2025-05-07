using FinanceManagementApi.Models.Branch;
using FinanceManagementApi.Models.Transaction;
using FinanceManagementApi.Models.User;
using Microsoft.EntityFrameworkCore;

namespace FinanceManagementApi.Context
{
    /// <summary>
    /// Interface que define o contexto do banco de dados para a aplicação.
    /// </summary>
    public interface IContext
    {
        /// <summary>
        /// Representa a tabela de usuários no banco de dados.
        /// </summary>
        DbSet<UserModel> Users { get; set; }

        /// <summary>
        /// Representa a tabela de branches no banco de dados.
        /// </summary>
        DbSet<BranchModel> Branches { get; set; }

        /// <summary>
        /// Representa a tabela de transações no banco de dados.
        /// </summary>
        DbSet<TransactionModel> Transactions { get; set; }

        /// <summary>
        /// Salva as alterações realizadas no contexto do banco de dados.
        /// </summary>
        /// <returns>Uma tarefa representando a operação assíncrona.</returns>
        Task Save();
    }
}