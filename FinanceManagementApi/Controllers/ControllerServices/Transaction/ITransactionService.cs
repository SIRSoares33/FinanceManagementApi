using System.Security.Claims;
using Finance.Dtos;

namespace FinanceManagementApi.Controllers.ControllerServices.Transaction;

/// <summary>
/// Interface que define os servi�os relacionados �s transa��es financeiras.
/// Fornece m�todos para cria��o, exclus�o, listagem e c�lculo de estat�sticas de transa��es.
/// </summary>
public interface ITransactionService
{
    /// <summary>
    /// Cria uma nova transa��o, vinculada a uma filial existente.
    /// </summary>
    /// <param name="dto">Dados da transa��o a ser criada.</param>
    /// <exception cref="Exception">Lan�ada se a filial especificada n�o existir.</exception>
    Task CreateTransactionAsync(TransactionDto dto);

    /// <summary>
    /// Calcula estat�sticas financeiras com base em uma lista de transa��es.
    /// </summary>
    /// <param name="transactions">Lista de transa��es.</param>
    /// <returns>Objeto contendo total de entradas, despesas e o saldo.</returns>
    TransactionStatisticDto GetTransactionStatistic(List<TransactionDto> transactions);

    /// <summary>
    /// Obt�m todas as transa��es ou somente as de uma filial espec�fica.
    /// </summary>
    /// <param name="branchId">Identificador da filial (opcional).</param>
    /// <returns>Lista de transa��es correspondentes.</returns>
    /// <exception cref="Exception">Lan�ada se a filial informada n�o existir.</exception>
    Task<List<TransactionDto>> GetAllBranchTransactionsAsync(int branchId);
     /// <summary>
    /// Obt�m todas as transa��es ou somente as de um usuário.
    /// </summary>
    /// <param name="branchId">Identificador da filial (opcional).</param>
    /// <returns>Lista de transa��es correspondentes.</returns>
    /// <exception cref="Exception">Lan�ada se a filial informada n�o existir.</exception>
    Task<List<TransactionDto>> GetAllUserTransactionsAsync(ClaimsPrincipal user);
    /// <summary>
    /// Exclui uma transa��o com base em seu identificador.
    /// </summary>
    /// <param name="id">Identificador da transa��o.</param>
    Task DeleteTransaction(int id);
}