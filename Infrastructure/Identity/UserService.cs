using Microsoft.AspNetCore.Identity;
using rezerwacje_lotnicze.Application.Interfaces;
using rezerwacje_lotnicze.Domain.Entities.User;

namespace rezerwacje_lotnicze.Infrastructure.Identity;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly IAuthService _authService;

    public UserService(UserManager<User> userManager, SignInManager<User> signInManager, IAuthService authService)
    {
        _userManager = userManager;
        _authService = authService;
    }

    public async Task<ServiceResult<string>> RegisterAsync(RegisterModel model)
    {
        if (await _userManager.FindByNameAsync(model.Username) != null)
            return ServiceResult<string>.Fail("User already exists.");

        var user = new User { UserName = model.Username };
        var result = await _userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
            return ServiceResult<string>.Fail(string.Join(", ", result.Errors.Select(e => e.Description)));

        await _userManager.AddToRoleAsync(user, "user");

        var token = _authService.GenerateJwtToken(user.UserName);
        return ServiceResult<string>.Ok("User registered successfully.", token);
    }

    public async Task<ServiceResult<string>> LoginAsync(LoginModel model)
    {
        var user = await _userManager.FindByNameAsync(model.Username);
        if (user == null)
            return ServiceResult<string>.Fail("Invalid username or password.");

        var passwordValid = await _userManager.CheckPasswordAsync(user, model.Password);
        if (!passwordValid)
            return ServiceResult<string>.Fail("Invalid username or password.");

        var token = _authService.GenerateJwtToken(user.UserName);
        return ServiceResult<string>.Ok("Login successful.", token);
    }
}
