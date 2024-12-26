using Google.Apis.Auth;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IConfiguration _configuration;

    public AuthController(IAuthService authService, IConfiguration configuration)
    {
        _authService = authService;
        _configuration = configuration;
    }

    [HttpPost("google")]
    public async Task<IActionResult> GoogleLogin([FromBody] GoogleLoginRequest request)
    {
        try
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings
            {
                Audience = new[] { _configuration["Authentication:Google:ClientId"] }
            };

            var payload = await GoogleJsonWebSignature.ValidateAsync(request.Credential, settings);
            var token = await _authService.CreateTokenFromGoogleUserAsync(payload);

            return Ok(new { token });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Invalid Google token" });
        }
    }
}

public class GoogleLoginRequest
{
    public string Credential { get; set; } = string.Empty;
}