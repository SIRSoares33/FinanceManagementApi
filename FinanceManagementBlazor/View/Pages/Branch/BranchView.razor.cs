using Finance.Dtos;
using FinanceManagementBlazor.Services.Branch;

namespace FinanceManagementBlazor.View.Pages.Branch;

public partial class BranchView
{
    #region Screen Attributes
    private bool showModal;
    private string messageErro = string.Empty;
    private BranchViewDependencies dependencies = new();
    #endregion

    #region Methods
    // OnInitialize
    protected override async Task OnInitializedAsync()
    {
        dependencies = await service.GetBranchViewDependenciesAsync();
    }

    // Manipulate transaction Methods
    protected async Task DeleteTransactionAsync(int id)
    {
        try
        {
            await service.DeleteTransactionAsync(id);
            Navigate.NavigateTo(Navigate.Uri, forceLoad: true);
        }
        catch (Exception ex)
        {
            messageErro = ex.Message;
        }
    }
    protected async Task SaveTransactionAsync(TransactionDto transaction)
    {
        try
        {
            await service.SaveTransactionAsync(transaction);
            Navigate.NavigateTo(Navigate.Uri, forceLoad: true);
        }
        catch (Exception ex)
        {
            messageErro = ex.Message;
        }
    }
    // Redirect to Home
    protected void GoToHome()
        => Navigate.NavigateTo("Home");
    #endregion
}