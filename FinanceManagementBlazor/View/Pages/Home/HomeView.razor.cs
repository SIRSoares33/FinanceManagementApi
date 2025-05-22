using Finance.Dtos;
using FinanceManagementBlazor.Services.Home;

namespace FinanceManagementBlazor.View.Pages.Home;

public partial class HomeView
{
    #region Screen Properties
    public HomeDependecies dependecies = new();

    public string messageErro = string.Empty;
    public bool showModal;
    #endregion

    #region Methods
    protected override async Task OnInitializedAsync()
    {
        try
        {
            dependecies = await service.GetHomeDependenciesAsync();
        }
        catch
        {
        }
    }

    // Methods to Manipulate Branchs
    protected async Task DeleteBranchAsync(int id)
    {
        try
        {
            await service.DeleteBranchAsync(id.ToString());

            Navigate.NavigateTo(Navigate.Uri, forceLoad: true);
        }
        catch (Exception ex)
        {
            messageErro = ex.Message;
        }
    }
    protected async Task SaveBranchAsync(BranchDto branchInfo)
    {
        try
        {
            await service.SaveBranchAsync(branchInfo);

            Navigate.NavigateTo(Navigate.Uri, forceLoad: true);
        }
        catch (Exception ex)
        {
            messageErro = ex.Message;
            showModal = false;
        }
    }
    // Redirect
    protected async Task GoToBranch(BranchDto branch)
    {
        await service.SetBranchStorageAsync(branch);

        Navigate.NavigateTo("Branch");
    }
    #endregion
}
