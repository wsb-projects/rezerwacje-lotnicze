using Microsoft.AspNetCore.Identity;
using rezerwacje_lotnicze.Domain.Entities.User;

namespace rezerwacje_lotnicze.Infrastructure.Seeders;

public class UserSeeder
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<User> _userManager;

    public UserSeeder(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public async Task SeedAsync()
    {
        var roles = new[] { "admin", "user" };

        foreach (var role in roles)
        {
            var roleExist = await _roleManager.RoleExistsAsync(role);
            if (!roleExist)
            {
                await _roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        var adminEmail = "admin@example.com";
        var adminPassword = "Admin123!";

        var adminUser = await _userManager.FindByEmailAsync(adminEmail);
        if (adminUser == null)
        {
            adminUser = new User
            {
                UserName = adminEmail,
                Email = adminEmail,
            };

            var createAdminResult = await _userManager.CreateAsync(adminUser, adminPassword);
            if (createAdminResult.Succeeded)
            {
                await _userManager.AddToRoleAsync(adminUser, "admin");
            }
        }
    }
}