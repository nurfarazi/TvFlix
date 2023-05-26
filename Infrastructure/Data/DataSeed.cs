using Core.Const;
using Core.Entity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Data;

public static class DataSeed
{
    public static async Task SeedUserAsync(UserManager<AppUser> userManager)
    {
        if (!userManager.Users.Any())
        {
            var user = new AppUser
            {
                Email = "admin@admin.com",
                EmailConfirmed = true,
                PhoneNumber = "01717369188",
                UserName = "admin@admin.com"
            };

            await userManager.CreateAsync(user, "admin@admin.com");
            await userManager.AddToRoleAsync(user, SystemRoles.Admin);
        }
    }

    public static async Task SeedUserRole(RoleManager<AppRole> roleManager)
    {
        string[] roleNames =
        {
            "Admin"
        };
        foreach (var roleName in roleNames)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist) await roleManager.CreateAsync(new AppRole { Name = roleName });
        }
    }
}