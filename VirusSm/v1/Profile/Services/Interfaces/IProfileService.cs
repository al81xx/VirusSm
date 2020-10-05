using System.Threading.Tasks;
using VirusSm.Database.Models;
using VirusSm.v1.Profile.Models.Request;

namespace VirusSm.v1.Profile.Services.Interfaces
{
    public interface IProfileService
    {
        Task<User?> Create(RegisterUserModel registerUserModel);
        Task<User?> GetProfile(int id);
    }
}