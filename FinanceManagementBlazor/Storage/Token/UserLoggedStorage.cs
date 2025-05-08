using Blazored.LocalStorage;
using FinanceManagementBlazor.Entities;

namespace FinanceManagementBlazor.Storage.Token
{
    public class UserLoggedStorage(ILocalStorageService storage) : IUserLoggedStorage
    {
        public async Task<LoggedUserModel?> GetItemAsync()
            => await storage.GetItemAsync<LoggedUserModel>("loggedUser");
        public async Task SetItemAsync(LoggedUserModel value)
            => await storage.SetItemAsync("loggedUser", value);
        public async Task RemoveItemAsync()
            => await storage.RemoveItemAsync("loggedUser");
        public async Task<bool> ItemExistsAsync()
            => await storage.ContainKeyAsync("loggedUser");
    }
}