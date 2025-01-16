using Microsoft.AspNetCore.Mvc;
using PortfolioAPI.Models;

namespace PortfolioAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult<string> Login(LoginRequest request)
        {
            if (_authService.ValidateCredentials(request.Username, request.Password))
            {
                var user = new AdminUser { Id = 1, Username = request.Username };
                var token = _authService.GenerateJwtToken(user);
                return Ok(new { token });
            }

            return Unauthorized();
        }
    }
}