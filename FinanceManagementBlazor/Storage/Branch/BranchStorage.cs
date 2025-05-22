using Blazored.LocalStorage;
using Finance.Dtos;

namespace FinanceManagementBlazor.Storage.Branch;

public class BranchStorage(ILocalStorageService storage) : IBranchStorage
{
    public async Task<BranchDto?> GetItemAsync()
        => await storage.GetItemAsync<BranchDto>("Branch");

    public async Task<bool> ItemExistsAsync()
        => await storage.ContainKeyAsync("Branch");

    public async Task RemoveItemAsync()
        => await storage.RemoveItemAsync("Branch");

    public async Task SetItemAsync(BranchDto value)
        => await storage.SetItemAsync("Branch", value);
}
