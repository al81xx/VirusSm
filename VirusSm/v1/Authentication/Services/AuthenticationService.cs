using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VirusSm.Database;
using VirusSm.Database.Models;
using VirusSm.v1.Authentication.Models.Request;
using VirusSm.v1.Authentication.Models.Response;
using VirusSm.v1.Authentication.Services.Interfaces;
using VirusSm.v1.Shared.Utils;

namespace VirusSm.v1.Authentication.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly DataContext _db;

        public AuthenticationService(DataContext db)
        {
            _db = db;
        }


        public async Task<LoggedInUserModel?> Login(LoginUserModel loginUserModel, LoginBy loginBy)
        {
            var user = await _db.Users.FirstOrDefaultAsync(
                u =>
                    loginBy == LoginBy.Username 
                        ? u.Username == loginUserModel.Username
                        : u.Email == loginUserModel.Email
            );
            
            if (user == null)
                return null;

            return user.VerifyPassword(loginUserModel.Password)
                ? user.ToExposedModel<User, LoggedInUserModel>()
                : null;
        }
    }
}