using eManager.Domain;

namespace eManager.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;

    internal sealed class Configuration : DbMigrationsConfiguration<eManager.Web.Infrastructure.DepartmentDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        // runs everytime execute update-database in package manager 
        protected override void Seed(eManager.Web.Infrastructure.DepartmentDb context)
        {
            context.Departments.AddOrUpdate(d => d.Name,
                    new Department() {Name="Engineering"},
                    new Department() {Name="Sales"},
                    new Department() {Name="Shipping"},
                    new Department() {Name="Human Resources"}
                );

            if(!Roles.RoleExists("Admin"))
            {
                Roles.CreateRole("Admin");
            }

            if(Membership.GetUser("sallen") == null)
            {
                Membership.CreateUser("sallen", "FluffyBunny@1");
                Roles.AddUserToRole("sallen", "Admin");
            }

        }
    }
}
