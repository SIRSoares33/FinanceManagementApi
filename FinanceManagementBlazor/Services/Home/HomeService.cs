using FinanceManagementBlazor.Entities;
using FinanceManagementBlazor.Services.HttpRequests.Branch;
using FinanceManagementBlazor.Services.HttpRequests.Transaction;
using FinanceManagementBlazor.Storage.Token;

namespace FinanceManagementBlazor.Services.Home
{
    public class HomeService(IBranchHttpService branchHttp, IUserLoggedStorage userStorage, ITransactionHttpService transactionHttpService) : IHomeService
    {
        public async Task<(string, List<BranchModel>, TransactionStatisticModel)> GetUserNameBranchsAndStatisticAsync()
            => ((await userStorage.GetItemAsync())?.Name ?? "", await branchHttp.GetAllBranchs(), await transactionHttpService.GetStatisticAsync(0));

        public async Task DeleteBranchAsync(string branchId)
            => await branchHttp.DeleteBranchAsync(branchId);

        public async Task SaveBranchAsync(BranchModel branchInfo)
            => await branchHttp.CreateBranch(branchInfo);
    }
}