using FinanceManagementBlazor.Entities;

namespace FinanceManagementBlazor.Storage.Token
{
    public interface IUserLoggedStorage : ILocalStorageManager<LoggedUserModel>
    {
    }
}