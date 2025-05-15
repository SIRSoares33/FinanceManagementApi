using FinanceManagementApi.Models.Transaction;

namespace FinanceManagementApi.Repository.Transaction
{
    public interface ITransactionRepository
    {
        Task AddTransactionAsync(TransactionModel transactionModel);
        Task DeleteTransactionAsync(int transactionId);
        Task UpdateTransactionAsync(int transactionId, TransactionModel transactionModel);
        Task<List<TransactionModel>> GetAllTransactionsAsync();
    }
}