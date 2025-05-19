using Finance.Dtos;
using FinanceManagementApi.Context.Tables;

namespace FinanceManagementApi.Services.Transaction;

public interface ITransactionService
{
    TransactionStatisticDto GetTransactionStatistic(List<TransactionTable> transactions);
}