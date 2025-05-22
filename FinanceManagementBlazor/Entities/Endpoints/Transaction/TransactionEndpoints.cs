namespace FinanceManagementBlazor.Entities.Endpoints.Transaction
{
    public class TransactionEndpoints : ITransactionEndpoints
    {
        public string Base => "Transaction/";
        public string GetAll => Base + "GetAllBranchTransactions/";
        public string GetAllStatistic => Base + "GetAllStatistics";
        public string GetBranchStatistic => Base + "GetBranchStatistics/";
        public string AddTransaction => Base + "AddTransaction";
        public string Delete => Base + "DeleteTransaction/";
    }
}