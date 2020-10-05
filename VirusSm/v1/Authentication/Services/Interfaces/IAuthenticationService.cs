using System.Threading.Tasks;
using VirusSm.v1.Authentication.Models.Request;
using VirusSm.v1.Authentication.Models.Response;

namespace VirusSm.v1.Authentication.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<LoggedInUserModel?> Login(LoginUserModel loginUserModel, LoginBy loginBy);
    }
}