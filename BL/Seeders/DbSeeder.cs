using Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Seeders
{
    public static class DbSeeder
    {
        public static async Task SeedRolesAndAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var Roles = new[] { "Owner", "Admin", "Cashier" }; // Simplified collection initialization
            foreach (var role in Roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
            string ownerEmail = "owner@system.com";
            string ownerPassword = "owner@123";
            if (await userManager.FindByEmailAsync(ownerEmail) == null)
            {
                var owneruser = new ApplicationUser
                {
                    UserName = ownerEmail,
                    Email = ownerEmail,
                    FullName = "System Owner",
                    EmailConfirmed = true
                };
                var createResult = await userManager.CreateAsync(owneruser, ownerPassword);
                if (createResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(owneruser, "Owner");
                }
            }
        }
    }
}
