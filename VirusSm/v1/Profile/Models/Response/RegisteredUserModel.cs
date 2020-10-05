using VirusSm.v1.Shared.Interfaces;

namespace VirusSm.v1.Profile.Models.Response
{
    public class RegisteredUserModel : IBaseMapperModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }
    }
}