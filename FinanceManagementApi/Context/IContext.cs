using FinanceManagementApi.Context.Tables;
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
        DbSet<UserTable> Users { get; set; }

        /// <summary>
        /// Representa a tabela de branches no banco de dados.
        /// </summary>
        DbSet<BranchTable> Branches { get; set; }

        /// <summary>
        /// Representa a tabela de transações no banco de dados.
        /// </summary>
        DbSet<TransactionTable> Transactions { get; set; }

        /// <summary>
        /// Salva as alterações realizadas no contexto do banco de dados.
        /// </summary>
        /// <returns>Uma tarefa representando a operação assíncrona.</returns>
        Task Save();
    }
}