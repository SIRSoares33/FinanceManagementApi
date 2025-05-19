using Finance.Dtos;
using FinanceManagementApi.Context.Tables;

namespace FinanceManagementApi.Services.Transaction;

public class TransactionService : ITransactionService
{
    public TransactionStatisticDto GetTransactionStatistic(List<TransactionTable> transactions)
    {
        var entry   = transactions.Where(x => x.IsEntry).Sum(x => x.Amount);
        var expense = transactions.Where(x => !x.IsEntry).Sum(x => x.Amount);

        return new ()
        {
            Entry   = entry,
            Expense = expense,
            Balance = entry - expense
        };
    }
}