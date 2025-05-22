namespace FinanceManagementBlazor.View.Pages.Register;

public partial class RegisterView
{
    #region Screen Properties
    private bool isLoading = false;
    private string messageErro = string.Empty;
    private string messageSuccess = string.Empty;
    #endregion

    #region Methods
    protected override async Task OnInitializedAsync()
    {
        if (await userStorage.ItemExistsAsync()) Navigation.NavigateTo("/Home");
    }

    public async Task OnRegister()
    {
        isLoading = true;
        messageErro = string.Empty;
        messageSuccess = string.Empty;
        StateHasChanged();

        try
        {
            await authService.Register(RegisterDto);
            messageSuccess = "Registro realizado com sucesso!";
        }
        catch (HttpRequestException)
        {
            messageErro = "Erro no servidor";
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
    // Redirect
    public void OnLogin()
        => Navigation.NavigateTo("/");
    #endregion
}
