using VirusSm.v1.Shared.Interfaces;

namespace VirusSm.v1.Authentication.Models.Response
{
    public class LoggedInUserModel : IBaseMapperModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }
    }
}