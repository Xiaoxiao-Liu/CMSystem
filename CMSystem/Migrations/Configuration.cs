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

        //bool AddUserAndRole(CMSystem.Models.ApplicationDbContext context)
        //{
        //    IdentityResult ir;
        //    var rm = new RoleManager<IdentityRole>
        //        (new RoleStore<IdentityRole>(context));
        //    ir = rm.Create(new IdentityRole("canEdit"));
        //    var um = new UserManager<ApplicationUser>(
        //        new UserStore<ApplicationUser>(context));
        //    var user = new ApplicationUser()
        //    {
        //    UserName = "rosa@email.com",
        //    };
        //    ir = um.Create(user, "password");
        //    if (ir.Succeeded == false)
        //        return ir.Succeeded;
        //    ir = um.AddToRole(user.Id, "canEdit");
        //    return ir.Succeeded;
        //}

        protected override void Seed(CMSystem.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
           
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
                var userToInsert = new ApplicationUser { UserName = "Customer" + i + "@email.com", Email = "Customer" + i + "@email.com",  Name = "Customer " + i };

                var result = userManager.Create(userToInsert, "password");

                if (result.Succeeded)
                {
                    userManager.AddToRole(userToInsert.Id, "Customer");
                    userManager.AddClaim(userToInsert.Id, (new Claim("Role", "Customer")));
                    userManager.AddClaim(userToInsert.Id, (new Claim("Permission", "Attempt Tests")));
                }

            }

            int memberNo = 100;
            var Member = new ApplicationUser { UserName = "Member1@email.com", Email = "Member1@email.com", Name = "Member1 " };

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
