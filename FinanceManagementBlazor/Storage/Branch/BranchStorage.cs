using Blazored.LocalStorage;
using FinanceManagementBlazor.Entities;

namespace FinanceManagementBlazor.Storage.Branch;

public class BranchStorage(ILocalStorageService storage) : IBranchStorage
{
    public async Task<BranchModel?> GetItemAsync()
        => await storage.GetItemAsync<BranchModel>("Branch");

    public async Task<bool> ItemExistsAsync()
        => await storage.ContainKeyAsync("Branch");

    public async Task RemoveItemAsync()
        => await storage.RemoveItemAsync("Branch");

    public async Task SetItemAsync(BranchModel value)
        => await storage.SetItemAsync("Branch", value);
}
