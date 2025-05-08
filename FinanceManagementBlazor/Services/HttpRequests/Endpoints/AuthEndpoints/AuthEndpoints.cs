using FinanceManagementBlazor.Services.HttpRequests.Endpoints.AuthEndpoints;
using FinanceManagementBlazor.Services.HttpRequests.Endpoints.BaseEndpoint;

namespace FinanceManagementBlazor.Services.HttpRequests.Endpoints.LoginEndpoints
{
    public class AuthEndpoints(IServerEndpoint serverEndpoint) : IAuthEndpoints
    {
        public string Base     => serverEndpoint.Base + "Auth/";
        public string Login    => Base + "Login";
        public string Register => Base + "Register";
    }
}