namespace CMSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Security.Claims;

    internal sealed class Configuration : DbMigrationsConfiguration<CMSystem.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CMSystem.Models.ApplicationDbContext context)
        {

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists("Customer"))
            {
                var role = new IdentityRole();
                role.Name = "Customer";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Member"))
            {
                var role = new IdentityRole();
                role.Name = "Member";
                roleManager.Create(role);
            }

            for (int i = 0; i < 6; i++)
            {
                var userToInsert = new ApplicationUser { UserName = "Customer" + i + "@email.com", Email = "Customer" + i + "@email.com", Name = "Customer " + i };

                var result = userManager.Create(userToInsert, "password");

                if (result.Succeeded)
                {
                    userManager.AddToRole(userToInsert.Id, "Customer");
                    userManager.AddClaim(userToInsert.Id, (new Claim("Role", "Customer")));
                    userManager.AddClaim(userToInsert.Id, (new Claim("Permission", "Attempt Tests")));
                }

            }

            var Member = new ApplicationUser { UserName = "Member1@email.com", Email = "Member1@email.com", Name = "Member1" };

            var result2 = userManager.Create(Member, "password");
            if (result2.Succeeded)
            {
                userManager.AddToRole(Member.Id, "Member");
                userManager.AddClaim(Member.Id, (new Claim("Role", "Member")));
                userManager.AddClaim(Member.Id, (new Claim("Permission", "Publish announcement")));
                userManager.AddClaim(Member.Id, (new Claim("Permission", "Attempt Tests")));
            }

        }


    }
}