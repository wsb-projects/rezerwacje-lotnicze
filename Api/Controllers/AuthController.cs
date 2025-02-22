using Microsoft.AspNetCore.Mvc;
using rezerwacje_lotnicze.Application.Interfaces;
using rezerwacje_lotnicze.Domain.Entities.User;

namespace rezerwacje_lotnicze.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IUserService _userService;

    public AuthController(IAuthService authService, IUserService userService)
    {
        _authService = authService;
        _userService = userService;
    }
    
    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterModel model)
    {
        var result = _userService.Register(model);
        if (!result.Result.Success)
        {
            return BadRequest(result.Result.Message);
        }

        var token = _authService.GenerateJwtToken(model.Username);
        return Ok(new { Token = token });
    }
    
    public IActionResult Login(string username, string password)
    {
        if (username == "validUser" && password == "validPassword")
        {
            var token = _authService.GenerateJwtToken(username);
            return Ok(new { token });
        }
        return Unauthorized();
    }

}