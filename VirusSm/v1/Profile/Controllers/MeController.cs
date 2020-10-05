using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VirusSm.Database.Models;
using VirusSm.v1.Authentication.Controllers;
using VirusSm.v1.Profile.Models.Response;
using VirusSm.v1.Profile.Services.Interfaces;
using VirusSm.v1.Shared.Utils;

namespace VirusSm.v1.Profile.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:version}/[controller]")]
    public class MeController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IProfileService _profileService;
        
        public MeController(ILogger<LoginController> logger, IProfileService profileService)
        {
            _logger = logger;
            _profileService = profileService;
        }
        
        [HttpGet]
        [Produces(typeof(RegisteredUserModel))]
        public async Task<IActionResult> Me()
        {
            var user = await _profileService.GetProfile(1);
            if (user == null)
                return BadRequest();
            
            var registeredUserModel = user.ToExposedModel<User, RegisteredUserModel>();
            return Ok(registeredUserModel);
        }
    }
}