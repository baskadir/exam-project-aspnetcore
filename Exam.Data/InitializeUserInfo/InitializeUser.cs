using Exam.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data.InitializeUserInfo
{
    public class InitializeUser
    {
        public async static void CreateUser(UserManager<AppUser> userManager)
        {
            AppUser appUser = new AppUser()
            {
                UserName = "baskadir"
            };

            if (await userManager.FindByNameAsync("baskadir") == null)
            {
                var result = await userManager.CreateAsync(appUser, "2");
            }
        }
    }
}
