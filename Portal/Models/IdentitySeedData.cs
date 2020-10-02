using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Portal
{
    public class IdentitySeedData
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "Secret123$";

        private const string playerUser = "Player";
        private const string playerPassword = "Secret123$";


        public static async Task EnsurePopulated(UserManager<IdentityUser> userManager)
        {
            IdentityUser user = await userManager.FindByIdAsync(adminUser);
            if (user == null)
            {
                user = new IdentityUser("Admin");
                await userManager.CreateAsync(user, adminPassword);
                await userManager.AddClaimAsync(user, new Claim("TeamManager", "true"));
            }

            IdentityUser player = await userManager.FindByIdAsync(playerUser);
            if (player == null)
            {
                player = new IdentityUser("Player");
                await userManager.CreateAsync(player, playerPassword);
            }
        }

    }
}