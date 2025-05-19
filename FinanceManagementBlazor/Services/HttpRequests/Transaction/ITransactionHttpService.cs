using Finance.Dtos;

using FinanceManagementBlazor.Services.HttpRequests.Transaction;

/// <summary>
/// Define os serviços HTTP relacionados a transações financeiras.
/// Fornece métodos para obter estatísticas, listar, adicionar e remover transações.
/// </summary>
public interface ITransactionHttpService
{
    /// <summary>
    /// Obtém as estatísticas de transações para o identificador informado.
    /// </summary>
    /// <param name="id">Identificador utilizado para buscar as estatísticas.</param>
    /// <returns>Um objeto <see cref="TransactionStatisticDto"/> contendo entrada, despesa e saldo.</returns>
    Task<TransactionStatisticDto> GetStatisticAsync(int id);

    /// <summary>
    /// Obtém a lista de transações de uma filial específica.
    /// </summary>
    /// <param name="branchId">Identificador da filial.</param>
    /// <returns>Uma lista de objetos <see cref="TransactionDto"/>.</returns>
    Task<List<TransactionDto>> GetTransactionsAsync(int branchId);

    /// <summary>
    /// Adiciona uma nova transação com as informações fornecidas.
    /// </summary>
    /// <param name="model">Objeto contendo os dados da transação.</param>
    Task AddTransactionAsync(TransactionDto model);

    /// <summary>
    /// Remove uma transação a partir do identificador informado.
    /// </summary>
    /// <param name="id">Identificador da transação a ser removida.</param>
    Task RemoveTransactionAsync(int id);
}
