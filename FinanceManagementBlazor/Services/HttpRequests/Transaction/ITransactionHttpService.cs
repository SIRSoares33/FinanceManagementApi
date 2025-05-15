using FinanceManagementBlazor.Services.HttpRequests.Transaction;

/// <summary>
/// Define os serviços HTTP relacionados a transações financeiras.
/// Fornece método para obter estatísticas de transações.
/// </summary>
public interface ITransactionHttpService
{
    /// <summary>
    /// Obtém as estatísticas de transações para o identificador informado.
    /// </summary>
    /// <param name="id">Identificador utilizado para buscar as estatísticas.</param>
    /// <returns>Um objeto <see cref="TransactionStatisticModel"/> contendo entrada, despesa e saldo.</returns>
    Task<TransactionStatisticModel> GetStatisticAsync(int id);
}
