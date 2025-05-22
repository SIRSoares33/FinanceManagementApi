using Finance.Dtos;
using FinanceManagementBlazor.Services.HttpRequests.Transaction;
using FinanceManagementBlazor.Storage.Branch;
using FinanceManagementBlazor.Storage.Token;

namespace FinanceManagementBlazor.Services.Home;

public class HomeService(IBranchHttpService branchHttp, IUserLoggedStorage userStorage, ITransactionHttpService transactionHttpService
    ,IBranchStorage branchStorage) : IHomeService
{
    public async Task<HomeDependecies> GetHomeDependenciesAsync()
        => new() 
        { 
            UserName  = (await userStorage.GetItemAsync())?.Name ?? throw new Exception("Não foi possível pegar o userName"), 
            Branchs   = await branchHttp.GetAllBranchsAsync(),
            Statistic = await transactionHttpService.GetStatisticAsync(null) 
        };

    public async Task DeleteBranchAsync(string branchId)
        => await branchHttp.DeleteBranchAsync(branchId);

    public async Task SaveBranchAsync(BranchDto branchInfo)
        => await branchHttp.CreateBranch(branchInfo);

    public async Task SetBranchStorageAsync(BranchDto branch)
        => await branchStorage.SetItemAsync(branch);
}

public class HomeDependecies
{
    public string UserName { get; set; } = string.Empty;
    public List<BranchDto> Branchs { get; set; } = [];
    public TransactionStatisticDto Statistic { get; set; } = new();
}