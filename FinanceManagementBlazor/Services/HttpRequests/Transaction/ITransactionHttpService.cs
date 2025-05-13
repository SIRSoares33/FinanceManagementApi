namespace FinanceManagementBlazor.Services.HttpRequests.Transaction;

public interface ITransactionHttpService
{
    Task<TransactionStatisticModel> GetStatisticAsync(int id);
}