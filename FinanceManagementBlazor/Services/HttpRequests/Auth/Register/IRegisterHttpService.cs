using FinanceManagementBlazor.Entities;

namespace FinanceManagementBlazor.Services.HttpRequests.Auth.Register
{
    public interface IRegisterHttpService
    {
        Task RegisterHttpRequest(AuthModel authModel);
    }
}