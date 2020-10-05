using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VirusSm.Database.Models;
using VirusSm.v1.Authentication.Controllers;
using VirusSm.v1.Profile.Models.Request;
using VirusSm.v1.Profile.Models.Response;
using VirusSm.v1.Profile.Services.Interfaces;
using VirusSm.v1.Shared.Utils;

namespace VirusSm.v1.Profile.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:version}/[controller]")]
    public class RegisterController: ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IProfileService _profileService;
        
        public RegisterController(ILogger<LoginController> logger, IProfileService profileService)
        {
            _logger = logger;
            _profileService = profileService;
        }
        
        [HttpPost]
        [Produces(typeof(RegisteredUserModel))]
        public async Task<IActionResult> Register([FromBody] RegisterUserModel registerUserModel)
        {
            var createdUser = await _profileService.Create(registerUserModel);
            if (createdUser == null)
                return BadRequest();

            var registeredUserModel = createdUser.ToExposedModel<User, RegisteredUserModel>();
            return Created(new Uri("/api/v1/me", UriKind.Relative), registeredUserModel);
        }
    }
}