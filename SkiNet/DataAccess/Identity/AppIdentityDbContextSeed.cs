using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Admin",
                    Email = "admin@test.com",
                    EmailConfirmed = true,
                    UserName = "admin@test.com",
                    Address = new Address
                    {
                        FirstName = "Admin",
                        LastName = "Admin",
                        Street = "7th Avenue",
                        City = "Cape Town",
                        Province = "Western Cape",
                        ZipCode = "7500"
                    }
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}
