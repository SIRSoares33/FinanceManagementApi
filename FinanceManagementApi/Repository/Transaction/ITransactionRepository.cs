using FinanceManagementApi.Context.Tables;

namespace FinanceManagementApi.Repository.Transaction;

public interface ITransactionRepository
{
    Task AddTransactionAsync(TransactionTable transactionModel);
    Task DeleteTransactionAsync(int transactionId);
    Task UpdateTransactionAsync(int transactionId, TransactionTable transactionModel);
    Task<List<TransactionTable>> GetAllTransactionsAsync();
}