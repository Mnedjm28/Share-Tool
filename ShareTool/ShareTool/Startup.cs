using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using ShareTool.Models;
using System;
using System.Runtime.InteropServices;

[assembly: OwinStartupAttribute(typeof(ShareTool.Startup))]
namespace ShareTool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            var context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                var admineRole = new IdentityRole();
                admineRole.Name = "Admin";
                roleManager.Create(admineRole);

                var adminUser = new ApplicationUser() { UserName = "admin@test.test", Email = "admin@test.test" };
                var result = userManager.Create(adminUser, password:"aZ123456-");

                if(result.Succeeded)
                {
                    userManager.AddToRole(adminUser.Id, admineRole.Name);
                }
            }
        }
    }
}