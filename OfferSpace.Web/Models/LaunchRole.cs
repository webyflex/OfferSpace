using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OfferSpace.BL.Models;
using OfferSpace.DAL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfferSpace.Web.Models
{
    public class LaunchRole
    {
        public LaunchRole()
        {
            using (OfferSpaceContext db = new OfferSpaceContext())
            {
                var userManager = new ApplicationUserManager(new UserStore<User>(db));
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

                // создаем две роли
                var role1 = new IdentityRole { Name = "admin" };
                var role2 = new IdentityRole { Name = "customer" };
                var role3 = new IdentityRole { Name = "worker" };
                var role4 = new IdentityRole { Name = "owner" };


                // добавляем роли в бд
                roleManager.Create(role1);
                roleManager.Create(role2);
                roleManager.Create(role3);
                roleManager.Create(role4);


                db.SaveChanges();
            }
        }
    }
}
