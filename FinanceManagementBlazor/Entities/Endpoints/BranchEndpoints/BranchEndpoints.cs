namespace FinanceManagementBlazor.Entities.Endpoints.BranchEndpoints
{
    public class BranchEndpoints : IBranchEndpoints
    {
        public string Base   => "Branch/";
        public string GetAll => Base + "GetAllBranchs";
        public string Create => Base + "CreateBranch";
        public string Update => Base + "UpdateBranch/";
        public string Delete => Base + "DeleteBranch/";
    }
}