using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneSignalTask.Infrastructure
{
    public static class IdentityDataInitializer
    {
        public static void SeedData(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            // Admin User
            if (userManager.FindByNameAsync("admin@admin.com").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "admin@admin.com";
                user.Email = "admin@admin.com";
                IdentityResult result = userManager.CreateAsync(user, "1Signal@AceAce").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,"Admin").Wait();
                }
            }

            // Data Entry Operator User
            if (userManager.FindByNameAsync("data@entry.com").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "data@entry.com";
                user.Email = "data@entry.com";
                IdentityResult result = userManager.CreateAsync
                (user, "1Signal@AceAce").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,"DataEntry").Wait();
                }
            }
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }


            if (!roleManager.RoleExistsAsync("DataEntry").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "DataEntry";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
        }
    }
}
