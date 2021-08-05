using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Blog.Models
{
	public class CommentModerator : ApplicationUser
	{
		// Props
		public string FirstName { get; set; }
		public int BanAppealsResolved { get; set; }
		public List<ApplicationUser> BannedUsers { get; set; }

		public static async Task Seed(ApplicationDbContext db)
		{
			var ModManager = new UserManager<CommentModerator>(new UserStore<CommentModerator>(db));
			var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
			var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

			string roleName = "CommentModerator";
			if (!RoleManager.RoleExists(roleName))
			{
				var role = new IdentityRole();
				role.Name = roleName;
				await RoleManager.CreateAsync(role);
			}

			if (ModManager.FindByName(roleName) == null)
			{
				var moderator = new CommentModerator();
				moderator.UserName = "CommentModerator";
				moderator.Email = "nathan.skiles77@gmail.com";
				moderator.BanAppealsResolved = 9000;
				moderator.BannedUsers = new List<ApplicationUser>();
				moderator.PasswordHash = "TechProject123";
				await ModManager.CreateAsync(moderator);
				await ModManager.AddToRoleAsync(moderator.Id, moderator.UserName);
			}

			string seedUser = "joeschmo";
			if (UserManager.FindByName(seedUser) == null)
			{
				var user = new ApplicationUser() { UserName = seedUser, Email = "joeschmo@schmo-mail.com" };
				await UserManager.CreateAsync(user);
			}

			db.SaveChanges();
		} 
	}

}