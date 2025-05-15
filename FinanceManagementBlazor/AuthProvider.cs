using System.Security.Claims;
using FinanceManagementBlazor.Entities;
using FinanceManagementBlazor.Storage.Token;
using Microsoft.AspNetCore.Components.Authorization;

namespace FinanceManagementBlazor
{
    public class AuthProvider(IUserLoggedStorage userStorage, ITokenStorage tokenStorage) : AuthenticationStateProvider
    {
        #region Methods
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var loggedUser = await userStorage.GetItemAsync();
            
            var claimsPrincipal = loggedUser is null ? 
                new ClaimsPrincipal( new ClaimsIdentity() ) :  
                new ClaimsPrincipal( new ClaimsIdentity(loggedUser.Name) );

            return new(claimsPrincipal);
        }

        public async Task UserLoggedIn(LoggedUserModel loggedUser, string token)
        {
            await userStorage.SetItemAsync(loggedUser);
            await tokenStorage.SetItemAsync(token);
            
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
        public async Task UserLoggedOut()
        {
            await userStorage.RemoveItemAsync();
            await tokenStorage.RemoveItemAsync();

            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
        #endregion
    }
}