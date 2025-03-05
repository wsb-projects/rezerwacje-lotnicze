using Microsoft.AspNetCore.Mvc;
using rezerwacje_lotnicze.Application.Interfaces;
using rezerwacje_lotnicze.Domain.Entities.User;

namespace rezerwacje_lotnicze.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        var result = await _userService.RegisterAsync(model);
        if (!result.Success) return BadRequest(result.Message);
        return Ok(new { Message = result.Message });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        var result = await _userService.LoginAsync(model);
        if (!result.Success) return Unauthorized(result.Message);
        return Ok(new { Token = result.Message });
    }
}