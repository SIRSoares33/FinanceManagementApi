namespace FinanceManagementBlazor.Entities.Endpoints.Transaction
{
    public class TransactionEndpoints : ITransactionEndpoints
    {
        public string Base => "Transaction/";
        public string GetStatistic => Base + "GetStatistics/";
    }
}
