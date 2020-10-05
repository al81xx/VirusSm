using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VirusSm.Database;
using VirusSm.Database.Models;
using VirusSm.v1.Profile.Models.Request;
using VirusSm.v1.Profile.Services.Interfaces;
using VirusSm.v1.Shared.Utils;

namespace VirusSm.v1.Profile.Services
{
    public class ProfileService : IProfileService
    {
        private readonly DataContext _db;

        public ProfileService(DataContext db)
        {
            _db = db;
        }

        public async Task<User?> Create(RegisterUserModel registerUserModel)
        {
            var newUser = registerUserModel.ToDbModel<RegisterUserModel, User>();
            newUser.SetPassword(registerUserModel.Password);
            
            var createdUser = await _db.Users.AddAsync(newUser);
            var saved = createdUser.State == EntityState.Added && await _db.SaveChangesAsync() > 0;
            
            return saved ? createdUser.Entity : null;
        }

        public async Task<User?> GetProfile(int id)
        {
            return await _db.Users.FindAsync(id);
        }
    }
}