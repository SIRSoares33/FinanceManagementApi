namespace FinanceManagementBlazor.Entities.Endpoints.Transaction;

public interface ITransactionEndpoints
{
    string Base { get; }
    string GetStatistic { get; }
    string AddTransaction { get; }
    string GetAll { get; }
    string Delete { get; }
}
