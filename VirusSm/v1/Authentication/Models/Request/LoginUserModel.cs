using System.ComponentModel.DataAnnotations;
using VirusSm.v1.Shared.Interfaces;

namespace VirusSm.v1.Authentication.Models.Request
{
    public enum LoginBy
    {
        Email,
        Username,
        None
    }
    
    public class LoginUserModel : IBaseMapperModel
    {
        [EmailAddress] 
        public string? Email { get; set; }
        
        public string? Username { get; set; }
        
        [Required] 
        public string Password { get; set; }
    }
}