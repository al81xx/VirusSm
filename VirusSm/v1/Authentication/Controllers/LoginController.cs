using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VirusSm.v1.Authentication.Models.Request;
using VirusSm.v1.Authentication.Models.Response;
using VirusSm.v1.Authentication.Services.Interfaces;

namespace VirusSm.v1.Authentication.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:version}/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IAuthenticationService _authenticationService;

        public LoginController(ILogger<LoginController> logger, IAuthenticationService authenticationService)
        {
            _logger = logger;
            _authenticationService = authenticationService;
        }
        
        [HttpPost]
        [Produces(typeof(LoggedInUserModel))]
        public async Task<IActionResult> Login(LoginUserModel loginUserModel)
        {
            var loginBy = !string.IsNullOrWhiteSpace(loginUserModel.Username)
                ? LoginBy.Username
                : !string.IsNullOrWhiteSpace(loginUserModel.Email)
                    ? LoginBy.Email
                    : LoginBy.None;
            
            if (loginBy == LoginBy.None)
                return BadRequest("Email or Username is required!");

            var loggedInUser = await _authenticationService.Login(loginUserModel, loginBy);
            
            if (loggedInUser == null)
                return NotFound();
            
            return Ok(loggedInUser);
        }
    }
}