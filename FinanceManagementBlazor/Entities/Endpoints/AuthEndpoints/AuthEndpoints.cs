using FinanceManagementBlazor.Services.HttpRequests.Endpoints.AuthEndpoints;

namespace FinanceManagementBlazor.Services.HttpRequests.Endpoints.LoginEndpoints
{
    public class AuthEndpoints : IAuthEndpoints
    {
        public string Base     => "Auth/";
        public string Login    => Base + "Login";
        public string Register => Base + "Register";
    }
}