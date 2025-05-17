using System.Runtime.CompilerServices;

namespace FinanceManagementBlazor.Entities.Endpoints.Transaction
{
    public class TransactionEndpoints : ITransactionEndpoints
    {
        public string Base => "Transaction/";
        public string GetAll => Base + "GetAllTransactions/";
        public string GetStatistic => Base + "GetStatistics/";
        public string AddTransaction => Base + "AddTransaction";
        public string Delete => Base + "DeleteTransaction/";
    }
}
