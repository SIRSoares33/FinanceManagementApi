namespace FinanceManagementBlazor.Entities.Endpoints.BranchEndpoints
{
    public interface IBranchEndpoints
    {
        string Base   { get; }
        string GetAll { get; }
        string Create { get; }
        string Update { get; }
        string Delete { get; }
    }
}