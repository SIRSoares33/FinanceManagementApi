using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;

namespace FinanceManagementBlazor.Storage.Token
{
    public class TokenStorage(ILocalStorageService storageAsync, ISyncLocalStorageService storageSync, NavigationManager navigation) : ITokenStorage
    {
        public async Task<string?> GetItemAsync()
            => await storageAsync.GetItemAsync<string>("token");

        public string? GetItem() 
            => storageSync.GetItem<string>("token");

        public async Task<bool> ItemExistsAsync()
            => await storageAsync.ContainKeyAsync("token");

        public async Task RemoveItemAsync()
            => await storageAsync.RemoveItemAsync("token");

        public async Task SetItemAsync(string value)
        {
            await storageAsync.SetItemAsync("token", value);
            navigation.NavigateTo(navigation.Uri, forceLoad: true);
        }
    }
}
