using GrandHayath.HotelBooking.Application.Auth.Command;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrandHayath.HotelBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("admin/login")]
        public async Task<IActionResult> AdminLogin([FromBody] LoginCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _mediator.Send(command);

                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None,
                    Expires = DateTime.UtcNow.AddDays(7)
                };

                Response.Cookies.Append("refreshToken", result.RefreshToken, cookieOptions);

                return Ok(new
                {
                    accessToken = result.AccessToken,
                    expiration = result.Expiration,
                    role = result.Role,
                    email = result.Email
                });
            }
            catch (Exception ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }
        [HttpPost("user/login")]
        public async Task<IActionResult> CustomerLogin([FromBody] CustomerLoginCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _mediator.Send(command);

                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None,
                    Expires = DateTime.UtcNow.AddDays(7)
                };

                Response.Cookies.Append("refreshToken", result.RefreshToken, cookieOptions);

                return Ok(new
                {
                    accessToken = result.AccessToken,
                    expiration = result.Expiration,
                    role = result.Role,
                    email = result.Email
                });
            }
            catch (Exception ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

        [HttpPost("user/register")]
        public async Task<IActionResult> CustomerRegister([FromBody] CustomerRegisterCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _mediator.Send(command);

                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None,
                    Expires = DateTime.UtcNow.AddDays(7)
                };
                Response.Cookies.Append("refreshToken", result.RefreshToken, cookieOptions);

                return Ok(new
                {
                    accessToken = result.AccessToken,
                    expiration = result.Expiration,
                    role = result.Role,
                    email = result.Email
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            if (string.IsNullOrEmpty(refreshToken))
                return Unauthorized("No refresh token found");

            try
            {
                var command = new RefreshTokenCommand { RefreshToken = refreshToken };
                var result = await _mediator.Send(command);

                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None,
                    Expires = DateTime.UtcNow.AddDays(7)
                };
                Response.Cookies.Append("refreshToken", result.RefreshToken, cookieOptions);

                return Ok(new
                {
                    accessToken = result.AccessToken,
                    expiration = result.Expiration,
                    role = result.Role,
                    email = result.Email
                });
            }
            catch (Exception ex)
            {
                var expiredCookie = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None,
                    Expires = DateTime.UtcNow.AddDays(-1),
                    Path = "/"
                };
                Response.Cookies.Append("refreshToken", "", expiredCookie);

                return Unauthorized(new { message = $"Invalid token. {ex.Message}" });
            }
        }
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            if (string.IsNullOrEmpty(refreshToken))
            {
                return Ok("No refresh token found.");
            }

            try
            {
                var command = new LogoutCommand { RefreshToken = refreshToken };
                await _mediator.Send(command);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error invalidating token: {ex.Message}");
            }

            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddDays(-1) ,
                Path = "/"
            };

            Response.Cookies.Append("refreshToken", "", cookieOptions);

            return Ok(new { message = "Logged out successfully" });
        }
    }
}
