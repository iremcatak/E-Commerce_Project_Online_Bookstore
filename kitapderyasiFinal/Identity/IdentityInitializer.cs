using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace kitapderyasiFinal.Identity
{
    public class IdentityInitializer:CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            if (!context.Roles.Any(i=>i.Name=="admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);

                var role = new ApplicationRole() { Name = "admin", Description = "admin rolü" }; ;
                manager.Create(role);
            }
            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);

                var role = new ApplicationRole() { Name = "user", Description = "user rolü" };
                manager.Create(role);
            }
            if (!context.Users.Any(i => i.Name == "Administrator"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser() { Name = "admin",Surname="null", UserName = "Administrator", Email="admin@outlook.com"};
                manager.Create(user,"666333");
                manager.AddToRole(user.Id, "admin");
            }
            if (!context.Users.Any(i => i.Name == "iremcatak"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser() { Name = "irem", Surname = "catak", UserName = "iremcatak", Email = "iremcatak@outlook.com" };
                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "user");
            }
            base.Seed(context); 
        }
    }
}