using Finance.Dtos;
using FinanceManagementBlazor.Services.HttpRequests.Transaction;
using FinanceManagementBlazor.Storage.Branch;

namespace FinanceManagementBlazor.Services.Branch;

public class BranchService(ITransactionHttpService transactionHttp, IBranchStorage branchStorage) : IBranchService
{
    public async Task<BranchViewDependencies> GetBranchViewDependenciesAsync()
    {
        var branch = await branchStorage.GetItemAsync() ?? throw new Exception("Branch não econtrada.");

        return new() 
        { 
            Branch       = branch, 
            Transactions = await transactionHttp.GetTransactionsAsync(branch.Id), 
            Statistic    = await transactionHttp.GetStatisticAsync(branch.Id) };
    }
    public async Task SaveTransactionAsync(TransactionDto model)
    {
        model.BranchId = (await branchStorage.GetItemAsync())?.Id ?? throw new Exception();
        await transactionHttp.AddTransactionAsync(model);
    }
    public async Task DeleteTransactionAsync(int id)
        => await transactionHttp.RemoveTransactionAsync(id);
}

public class BranchViewDependencies
{
    public BranchDto Branch { get; set; } = new();
    public List<TransactionDto> Transactions { get; set; } = [];
    public TransactionStatisticDto Statistic { get; set; } = new();
}