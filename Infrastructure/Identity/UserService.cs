using Microsoft.AspNetCore.Identity;
using rezerwacje_lotnicze.Application.Interfaces;
using rezerwacje_lotnicze.Domain.Entities.User;

namespace rezerwacje_lotnicze.Infrastructure.Identity;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public UserService(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<ServiceResult> Register(RegisterModel model)
    {
        var existingUser = await _userManager.FindByNameAsync(model.Username);
        if (existingUser != null)
        {
            return new ServiceResult(false, "User already exists.");
        }

        var user = new User { UserName = model.Username };
        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            return new ServiceResult(true, "User registered successfully.");
        }

        return new ServiceResult(false, string.Join(", ", result.Errors.Select(e => e.Description)));
    }

    public async Task<ServiceResult> Login(LoginModel model)
    {
        var user = await _userManager.FindByNameAsync(model.Username);
        if (user == null)
        {
            return new ServiceResult(false, "Invalid username or password.");
        }

        var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

        if (result.Succeeded)
        {
            return new ServiceResult(true, "Login successful.");
        }

        return new ServiceResult(false, "Invalid username or password.");
    }
}
