using System.ComponentModel.DataAnnotations;
using VirusSm.v1.Shared.Interfaces;

namespace VirusSm.v1.Profile.Models.Request
{
    public class RegisterUserModel : IBaseMapperModel
    {
        [Required]
        public string Username { get; set; }
        
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
    }
}