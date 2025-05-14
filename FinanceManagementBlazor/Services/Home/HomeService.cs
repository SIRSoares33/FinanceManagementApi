using FinanceManagementBlazor.Entities;
using FinanceManagementBlazor.Services.HttpRequests.Branch;
using FinanceManagementBlazor.Services.HttpRequests.Transaction;
using FinanceManagementBlazor.Storage.Token;

namespace FinanceManagementBlazor.Services.Home
{
    public class HomeService(IBranchHttpService branchHttp, IUserLoggedStorage userStorage, ITransactionHttpService transactionHttpService) : IHomeService
    {
        public async Task<HomeDependecies> GetHomeDependencies()
            => new() 
            { 
                UserName  = (await userStorage.GetItemAsync())?.Name ?? throw new Exception("Não foi possível pegar o userName"), 
                Branchs   = await branchHttp.GetAllBranchsAsync(),
                Statistic = await transactionHttpService.GetStatisticAsync(0)
            };

        public async Task DeleteBranchAsync(string branchId)
            => await branchHttp.DeleteBranchAsync(branchId);

        public async Task SaveBranchAsync(BranchModel branchInfo)
            => await branchHttp.CreateBranch(branchInfo);
    }

    public class HomeDependecies
    {
        public string UserName { get; set; } = string.Empty;
        public List<BranchModel> Branchs { get; set; } = [];
        public TransactionStatisticModel Statistic { get; set; } = new();
    }
}