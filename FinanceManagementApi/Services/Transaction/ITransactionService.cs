using FinanceManagementApi.Models.Transaction;

namespace FinanceManagementApi.Services.Transaction
{
    public interface ITransactionService
    {
        TransactionStatistic GetTransactionStatistic(List<TransactionModel> transactions);
    }
}