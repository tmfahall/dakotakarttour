using DKTFinal.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DKTFinal.helpers
{
    public class IdentityHelper
    {
        internal static void SeedIdentities(DbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists(RoleNames.ROLE_ADMINISTRATOR))
            {
                var roleresult = roleManager.Create(new IdentityRole(RoleNames.ROLE_ADMINISTRATOR));
            }

            if (!roleManager.RoleExists(RoleNames.ROLE_CONTRIBUTOR))
            {
                var roleresult = roleManager.Create(new IdentityRole(RoleNames.ROLE_CONTRIBUTOR));
            }

            if (!roleManager.RoleExists(RoleNames.ROLE_READER))
            {
                var roleresult = roleManager.Create(new IdentityRole(RoleNames.ROLE_READER));
            }

            string userName = "tmfahall@gmail.com";
            string password = "passwordToChange1!";

            string userName2 = "brandt@email.com";
            string password2 = "passwordToChange2!";

            string userName3 = "anthony@email.com";
            string password3 = "passwordToChange3!";
                
            ApplicationUser user = userManager.FindByName(userName);
            if (user == null)
            {
                user = new ApplicationUser()
                {
                    UserName = userName,
                    Email = userName,
                    EmailConfirmed = true
                };
                IdentityResult userResult = userManager.Create(user, password);
                if (userResult.Succeeded)
                {
                    var result = userManager.AddToRole(user.Id, RoleNames.ROLE_ADMINISTRATOR);
                }
            }

            ApplicationUser user2 = userManager.FindByName(userName2);
            if (user2 == null)
            {
                user2 = new ApplicationUser()
                {
                    UserName = userName2,
                    Email = userName2,
                    EmailConfirmed = true
                };
                IdentityResult userResult = userManager.Create(user2, password2);
                if (userResult.Succeeded)
                {
                    var result = userManager.AddToRole(user2.Id, RoleNames.ROLE_ADMINISTRATOR);
                }
            }

            ApplicationUser user3 = userManager.FindByName(userName3);
            if (user3 == null)
            {
                user3 = new ApplicationUser()
                {
                    UserName = userName3,
                    Email = userName3,
                    EmailConfirmed = true
                };
                IdentityResult userResult = userManager.Create(user3, password3);
                if (userResult.Succeeded)
                {
                    var result = userManager.AddToRole(user3.Id, RoleNames.ROLE_ADMINISTRATOR);
                }
            }

        }

    }
}