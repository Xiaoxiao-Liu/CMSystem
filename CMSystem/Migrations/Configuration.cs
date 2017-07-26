namespace CMSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

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
            AddUsers(context);
            //AddUserAndRole(context);

        }

        void AddUsers(ApplicationDbContext context)
        {
            var user_Customer = new ApplicationUser { UserName = "customer@email.com" };
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            userManager.Create(user_Customer, "password");

            var user_Staff = new ApplicationUser { UserName = "Manager@email.com" };

            userManager.Create(user_Staff, "password");

            //}

        }
    }
}
