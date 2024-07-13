using Mavericks.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mavericks.Data.DataSeed
{
    public static class AppIdentityDbContextSeed
    {
        public async static Task SeedUserAsync(UserManager<AppUser> _userManager)
        {
            if (_userManager.Users.Count() == 0)
            {
                var user = new AppUser()
                {
                    DisplayName = "Maverick",
                    Email = "Maverick@gmail.com",
                    UserName = "Maverick",
                    PhoneNumber = "123456789"
                };
                await _userManager.CreateAsync(user,"Admin123@");
            }
        }
    }
}
