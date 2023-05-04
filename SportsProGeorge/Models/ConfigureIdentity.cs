using Microsoft.AspNetCore.Identity;

namespace SportsProGeorge.Models
{
	public class ConfigureIdentity
	{
		public static async Task CreateAdminUserAsync(IServiceProvider provider)
		{

			var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();

			var userManager = provider.GetRequiredService<UserManager<User>>();

			string username = "admin";
			string password = "Admin123";
			string roleName = "Admin";

			if (await roleManager.FindByNameAsync("Admin") == null)
			{
				await roleManager.CreateAsync(new IdentityRole("Admin"));

				User user = new User { UserName = username };
				var result = await userManager.CreateAsync(user, password);
				if (result.Succeeded)
				{
					await userManager.AddToRoleAsync(user, "Admin");
				}
			}
		}
	}
}
