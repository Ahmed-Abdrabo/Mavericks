using Mavericks.Entities;
using Microsoft.AspNetCore.Identity;

namespace Mavericks.Services
{
    public interface IAuthService
    {
        Task<string> GenerateTokenAsync(AppUser User, UserManager<AppUser> userManager);

    }
}
