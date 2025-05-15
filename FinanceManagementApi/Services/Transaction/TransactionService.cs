using FinanceManagementApi.Models.Transaction;

namespace FinanceManagementApi.Services.Transaction
{
    public class TransactionService : ITransactionService
    {
        public TransactionStatistic GetTransactionStatistic(List<TransactionModel> transactions)
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
}