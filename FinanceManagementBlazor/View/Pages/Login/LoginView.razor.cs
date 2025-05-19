using Microsoft.AspNetCore.Components;

namespace FinanceManagementBlazor.View.Pages.Login;

public partial class LoginView : ComponentBase
{
    #region System Properties
    string messageErro = string.Empty;
    bool isLoading = false;
    #endregion

    #region Handlers
    protected override async Task OnInitializedAsync()
    {
        if (await userStorage.ItemExistsAsync()) Navigation.NavigateTo("/Home");
    }

    public async Task OnLogin()
    {
        isLoading = true;

        try
        {
            await authService.Login(loginDto);
            Navigation.NavigateTo("/Home");
        }
        catch (HttpRequestException)
        {
            messageErro = "Erro ao conectar com o servidor! Verifique sua conexão com a internet.";
        }
        catch (Exception ex)
        {
            messageErro = ex.Message;
        }
        finally
        {
            isLoading = false;
        }
    }
    public void OnRegister()
        => Navigation.NavigateTo("/Register");
#endregion
}
