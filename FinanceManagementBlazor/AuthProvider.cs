using System.Security.Claims;
using FinanceManagementBlazor.Entities;
using FinanceManagementBlazor.Storage.Token;
using Microsoft.AspNetCore.Components.Authorization;

namespace FinanceManagementBlazor
{
    public class AuthProvider(IUserLoggedStorage storage) : AuthenticationStateProvider
    {
        #region Methods
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var loggedUser = await storage.GetItemAsync();
            
            var claimsPrincipal = loggedUser is null ? 
                new ClaimsPrincipal( new ClaimsIdentity() ) :  
                new ClaimsPrincipal( new ClaimsIdentity(loggedUser.Name) );

            return new(claimsPrincipal);
        }

        public async Task UserLoggedIn(LoggedUserModel loggedUser)
        {
            await storage.SetItemAsync(loggedUser);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
        public async Task UserLoggedOut()
        {
            await storage.RemoveItemAsync();
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
        #endregion
    }
}