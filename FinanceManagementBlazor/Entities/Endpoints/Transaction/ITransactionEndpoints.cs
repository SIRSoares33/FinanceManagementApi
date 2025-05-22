namespace FinanceManagementBlazor.Entities.Endpoints.Transaction;

public interface ITransactionEndpoints
{
    string Base { get; }
    public string GetAllStatistic { get; }
    public string GetBranchStatistic { get; }
    string AddTransaction { get; }
    string GetAll { get; }
    string Delete { get; }
}
